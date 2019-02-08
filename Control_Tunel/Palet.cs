using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using Utiles;

namespace Control_Tunel
{
    class Palet
    {
        private string _SSCC { get; set; }
        private int _ID { get; set; }
        private bool _procesado { get; set; }
        private Quality con = new Quality();
        public bool existe() { return existe_; }
        private bool existe_ { get; set; }
        public bool introducido() { return introducido_; }
        private bool introducido_ { get; set; }
        //private int unidades_ { get; set; }
        public Palet(string SCCC)
        {
            resto_dia = false;
            _SSCC = SCCC;
            existe_ = _existe();
            introducido_ = _introducido();
            _ID = _Id();
           //  = _unidades();
        }
        private bool _existe() {
            bool result = false;
            string sql = "select count(*) from DATOS_ORGANOLEPTICO where SSCC='"+_SSCC+"'";
            string conteo_s=con.sql_string(sql);
            int conteo_i = 0;
            int.TryParse(conteo_s, out conteo_i);
            if (conteo_i > 0)
                result = true;

            return result;
        }

        private int _Id()
        {
            
            string sql = "select ID from CONTROL_TUNEL where SSCC='" + _SSCC + "' and TUNEL<3";
            string conteo_s = con.sql_string(sql);
            int conteo_i = 0;
            int.TryParse(conteo_s, out conteo_i);
         

            return conteo_i;
        }
       

        private int _Id( int tunel)
        {

            string sql = "select ID from CONTROL_TUNEL where SSCC='" + _SSCC + "' and TUNEL="+tunel.ToString();
            string conteo_s = con.sql_string(sql);
            int conteo_i = 0;
            int.TryParse(conteo_s, out conteo_i);


            return conteo_i;
        }
        public int uds()
        {
            //select UdActual from sscc inner join SSCC_CON on SSCC_CON.IdPadre=sscc.id where sscc='584037000004226030'
            string sql = "select UdActual from sscc inner join SSCC_CON on SSCC_CON.IdPadre=sscc.id where SSCC='" + _SSCC + "'";
            string conteo_s = con.sql_string(sql);
            int conteo_i = 0;
            int.TryParse(conteo_s, out conteo_i);
            return conteo_i;
        }
        private bool _introducido()
        {
            bool result = false;
            string sql = "SELECT count(*) FROM [CONTROL_TUNEL] WHERE SSCC = '" + _SSCC+ "' and (TUNEL<3 or TUNEL=6)";
            string conteo_s = con.sql_string(sql);
            int conteo_i = 0;
            int.TryParse(conteo_s, out conteo_i);
            if (conteo_i > 0 )
                result = true;

            return result;
        }


        private bool _introducido( int tunel)
        {
            bool result = false;
            string sql = "SELECT count(*) FROM [CONTROL_TUNEL] WHERE fecha_creacion>DATEADD(minute,-15, getdate()) and  SSCC = '" + _SSCC + "' and TUNEL="+tunel.ToString();
            string conteo_s = con.sql_string(sql);
            int conteo_i = 0;
            int.TryParse(conteo_s, out conteo_i);
            if (conteo_i > 0)
                result = true;

            return result;
        }
        private bool resto_dia { get; set; }
        private DateTime Fecha_intro (string hora)
        {
            DateTime actual = DateTime.Now;
            
            int anyo = actual.Year;
            int mes = actual.Month;
            int dia = actual.Day;
            TimeSpan ts = TimeSpan.Parse(hora);
            int hora_ = ts.Hours;
            int min = ts.Minutes;
            DateTime fecha_intro = new DateTime(anyo, mes, dia, hora_, min, 0, 0);
            if (actual <= fecha_intro) {
               
                fecha_intro = fecha_intro.AddDays(-1); //new DateTime(anyo, mes, dia-1, hora_, min, 0, 0);
                resto_dia = true;
            }
            return fecha_intro;
        }

        public int Comprobar_horas(string hora)
        {
           // DateTime fecha_intro = Fecha_intro(hora);
            string sql = @"select  DATEDIFF(minute, CONVERT(DATETIME,'" + Fecha_intro(hora).ToString() + @"',103),DATOS_ORGANOLEPTICO.FECHA_SSCC_CON)/60 
 from DATOS_ORGANOLEPTICO where DATOS_ORGANOLEPTICO.SSCC = '" + _SSCC + @"'";
            int horas = -9999;
            string resul = con.sql_string(sql);
            int.TryParse(resul, out horas);
            return horas;

        }
        public bool Barrar_Ultimo_Quality()
        {
            if (existe_ == true) { 
                string sql = @"with Tempo as (
SELECT tt.*
FROM CONTROL_TUNEL tt
INNER JOIN
    (SELECT sscc as Matricula, MAX(FECHA_CREACION) AS MaxDateTime
    FROM CONTROL_TUNEL
    GROUP BY sscc) groupedtt 
ON tt.sscc = groupedtt.Matricula 
AND tt.FECHA_CREACION = groupedtt.MaxDateTime)
delete from Tempo set tunel=1 where sscc='" + _SSCC + @"'";
            con.sql_update(sql);
            }
            return true;
        }
        public bool setTemperatura(string Tempe, int tunel) {
            double tempo_temperatura;
            double _Temperatura;
            _Temperatura = -999.999;
            string Tempe_2 = Tempe.Replace('.', ',');
             if (double.TryParse(Tempe_2, out tempo_temperatura))
                {
                    _Temperatura = tempo_temperatura;
                }
               
            return insertar_temperatura(_Temperatura, tunel);
        }
        public bool insertar_temperatura(double _Temperatura, int tunel)
        {
            bool exito;
            if (_Temperatura == -999.999)
            {
                return false;
            }
            try
            {
                string sql = "insert into [QC600].[dbo].[dbControlTemperatura] (SSCC, Temperatura, Fecha, procesado,Tunel) values(" + _SSCC + ", " + _Temperatura.ToString().Replace(',', '.') + ",GETDATE(),0,"+ tunel.ToString()+")";
                con.sql_update(sql);
               

                string sql_select = @"select [Temperatura]  FROM [QC600].[dbo].[dbControlTemperatura] where [SSCC] like '" + _SSCC + @"'";

                double temp = -999.999;
                double.TryParse(con.sql_string(sql_select), out temp);


                if (temp != -999.999)
                {
                    exito = true;
                   
                }
                else
                {
                    exito = false;
                }
            }
            catch (Exception ex)
            {
                exito = false;
                
            }


            return exito;
        }
        public bool Insertar_Quality(string tunel, string hora)
        {
            string sql ="";
            int tun = 1;
            int.TryParse(tunel, out tun);
            if (tun == 6) { tun = 8; }
            if (_introducido(tun) == false ) { 
            
             sql= @"INSERT INTO CONTROL_TUNEL (SSCC, TUNEL, FECHA_INTRODUCIDA, FECHA_CREACION, PROCESADO) VALUES ('"+_SSCC + @"'," + tun.ToString() + @",CONVERT(DATETIME,'"+ Fecha_intro(hora).ToString() + @"',103),getdate(),0" + @") ";

            }else {

                sql = @"UPDATE CONTROL_TUNEL SET SSCC='" + _SSCC + @"', TUNEL=" + tun.ToString() + @", FECHA_INTRODUCIDA=CONVERT(DATETIME,'" + Fecha_intro(hora).ToString() + @"',103) , FECHA_CREACION=getdate(), PROCESADO=0 WHERE SSCC='" + _SSCC + @"' and ID=" + _Id(tun).ToString();
              //  if( tun < 3)
               //     sql = @"UPDATE CONTROL_TUNEL SET SSCC='" + _SSCC + @"', TUNEL=" + tun.ToString() + @", FECHA_INTRODUCIDA=CONVERT(DATETIME,'" + Fecha_intro(hora).ToString() + @"',103) , FECHA_CREACION=getdate(), PROCESADO=0 WHERE SSCC='" + _SSCC + @"' and ID=" + _ID.ToString();
            }

            return con.sql_update(sql);
        }

        public int Insertar_Quality(string tunel, string hora, string unidades_intro)
        {
            string sql = "";
            int tun = 1;
            int unidades = 1;
            int.TryParse(tunel, out tun);
            if (tun == 6) { tun = 8; }
            int.TryParse(unidades_intro, out unidades);
            int unidades_sscc_con = uds();
            int resultado = -1;
            if (unidades_sscc_con == unidades)
            {
                resultado = 1;
           
            if (_introducido(tun) == false)
            {

                sql = @"INSERT INTO CONTROL_TUNEL (SSCC, TUNEL, FECHA_INTRODUCIDA, FECHA_CREACION, PROCESADO,UNIDADES) VALUES ('" + _SSCC + @"'," + tun.ToString() + @",CONVERT(DATETIME,'" + Fecha_intro(hora).ToString() + @"',103),getdate(),0,"+unidades.ToString() + @") ";

            }
            else
            {

                sql = @"UPDATE CONTROL_TUNEL SET SSCC='" + _SSCC + @"', TUNEL=" + tun.ToString() + @", FECHA_INTRODUCIDA=CONVERT(DATETIME,'" + Fecha_intro(hora).ToString() + @"',103) , FECHA_CREACION=getdate(), PROCESADO=0, UNIDADES=" + unidades.ToString() + "  WHERE SSCC='" + _SSCC + @"' and ID=" + _Id(tun).ToString();
                //  if( tun < 3)
                //     sql = @"UPDATE CONTROL_TUNEL SET SSCC='" + _SSCC + @"', TUNEL=" + tun.ToString() + @", FECHA_INTRODUCIDA=CONVERT(DATETIME,'" + Fecha_intro(hora).ToString() + @"',103) , FECHA_CREACION=getdate(), PROCESADO=0 WHERE SSCC='" + _SSCC + @"' and ID=" + _ID.ToString();
            }
            if (!con.sql_update(sql))
                resultado = 2;
            }
            return resultado;
        }
        public bool Update_Quality(string tunel, string hora, string unidades)
        {
            string sql = "";
            int tun = 1;
            int.TryParse(tunel, out tun);


            sql = @"UPDATE CONTROL_TUNEL SET SSCC='" + _SSCC + @"', TUNEL=" + tun.ToString() + @", FECHA_INTRODUCIDA=CONVERT(DATETIME,'" + Fecha_intro(hora).ToString() + @"',103) , FECHA_CREACION=getdate(), PROCESADO=0, UNIDADES="+unidades.ToString()+" WHERE SSCC='" + _SSCC + @"' and ID=" + _Id().ToString();

            return con.sql_update(sql);
        }
        public bool Update_Quality(string tunel, string hora)
        {
            string sql = "";
            int tun = 1;
            int.TryParse(tunel, out tun);
            

                sql = @"UPDATE CONTROL_TUNEL SET SSCC='" + _SSCC + @"', TUNEL=" + tun.ToString() + @", FECHA_INTRODUCIDA=CONVERT(DATETIME,'" + Fecha_intro(hora).ToString() + @"',103) , FECHA_CREACION=getdate(), PROCESADO=0 WHERE SSCC='" + _SSCC + @"' and ID=" + _Id().ToString(); 
           
            return con.sql_update(sql);
        }



    }
}
