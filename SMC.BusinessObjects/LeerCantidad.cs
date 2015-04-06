using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMC.BusinessObjects
{

    public class LeerCantidad
    {
        private String[] UNIDADES = { "", "un ", "dos ", "tres ", "cuatro ", "cinco ", "seis ", "siete ", "ocho ", "nueve " };
        private String[] DECENAS = {"diez ", "once ", "doce ", "trece ", "catorce ", "quince ", "dieciseis ",
        "diecisiete ", "dieciocho ", "diecinueve", "veinte ", "treinta ", "cuarenta ",
        "cincuenta ", "sesenta ", "setenta ", "ochenta ", "noventa "};
        private String[] CENTENAS = {"", "ciento ", "doscientos ", "trecientos ", "cuatrocientos ", "quinientos ", "seiscientos ",
        "setecientos ", "ochocientos ", "novecientos "};


        public String Convertir(String numero, int mayusculas)
        {

            String literal = "";
            String parte_decimal;
            //si el numero utiliza (.) en lugar de (,) -> se reemplaza
            numero = numero.Replace(".", ",");

            //si el numero no tiene parte decimal, se le agrega ,00
            if (numero.IndexOf(",") == -1)
            {
                numero = numero + ",00";
            }

            String[] Num = numero.Split(',');

            //de da formato al numero decimal
           // parte_decimal = " con " + Num[1] + "/100 dolares americanos.";
            parte_decimal = " con " + Convert.ToDouble(Num[1])/100+" dolares americanos.";
            //se convierte el numero a literal
            if (int.Parse(Num[0]) == 0)
            {//si el valor es cero                
                literal = "cero ";
            }
            else if (int.Parse(Num[0]) > 999999)
            {//si es millon
                literal = getMillones(Num[0]);
            }
            else if (int.Parse(Num[0]) > 999)
            {//si es miles
                literal = getMiles(Num[0]);
            }
            else if (int.Parse(Num[0]) > 99)
            {//si es centena
                literal = getCentenas(Num[0]);
            }
            else if (int.Parse(Num[0]) > 9)
            {//si es decena
                literal = getDecenas(Num[0]);
            }
            else
            {//sino unidades -> 9
                literal = getUnidades(Num[0]);
            }
            //devuelve el resultado en mayusculas o minusculas
            if (mayusculas == 1)
            {
                return (literal + parte_decimal).ToUpper();
            }
            else
            {
                return (literal + parte_decimal);
            }
            //}
            //else
            //{//error, no se puede convertir
            //    return literal = null;
            //}
        }

        private String getUnidades(String num)
        {
            int n = int.Parse(num);
            if (n < 10)
            {//para casos como -> 01 - 09
                return UNIDADES[n];
            }
            else
            {
                n = n % 10;
                return (UNIDADES[n]);
            }

        }

        private String getMillones(String numero)
        {
            //000 000 000        
            //se obtiene los miles
            String miles = numero.Substring(numero.Length - 6);
            //se obtiene los millones
            String millon = numero.Substring(0, numero.Length - 6);
            String n = "";
            if (millon.Length > 1)
            {
                n = getCentenas(millon) + " millones ";
            }
            else
            {
                n = getUnidades(millon) + " millones ";
            }
            return n + getMiles(miles);
        }

        private String getDecenas(String num)
        {// 99                        
            int n = int.Parse(num);
            if (n < 10)
            {//para casos como -> 01 - 09
                return getUnidades(num);
            }
            else if (n > 19)
            {//para 20...99
                String u = getUnidades(num);
                if (u.Equals(""))
                { //para 20,30,40,50,60,70,80,90
                    return DECENAS[int.Parse(num.Substring(0, 1)) + 8];
                }
                else
                {
                    return DECENAS[int.Parse(num.Substring(0, 1)) + 8] + " y " + u;
                }
            }
            else
            {//numeros entre 11 y 19
                return DECENAS[n - 10];
            }
        }

        private String getCentenas(String num)
        {// 999 o 099
            num = num.Trim();
            if (int.Parse(num) > 99)
            {//es centena
                if (int.Parse(num) == 100)
                {//caso especial
                    return " cien ";
                }
                else
                {
                    //MessageBox.Show("num=="+num+"subs 0,2"+ num.Substring(0, 2) + "-uni:" + num.Substring(2));

                    return CENTENAS[int.Parse(num.Substring(0, 1))] + getDecenas(num.Substring(1));
                }
            }
            else
            {//por Ej. 099 
                //se quita el 0 antes de convertir a decenas
                return getDecenas(int.Parse(num) + "");
            }
        }

        private String getMiles(String numero)
        {// 999 999
            //obtiene las centenas
            String c = numero.Substring(numero.Length - 3);
            //obtiene los miles
            String m = numero.Substring(0, numero.Length - 3);
            String n = "";
            //se comprueba que miles tenga valor entero
            if (int.Parse(m) > 0)
            {
                n = getCentenas(m);
                return n + " mil " + getCentenas(c);
            }
            else
            {
                return "" + getCentenas(c);
            }

        }

        public String Convertir001(String numero, bool mayusculas)
        {

            String literal = "";
            String parte_decimal;
            //si el numero utiliza (.) en lugar de (,) -> se reemplaza
            numero = numero.Replace(".", ",");

            //si el numero no tiene parte decimal, se le agrega ,00
            if (numero.IndexOf(",") == -1)
            {
                numero = numero + ",00";
            }

            //se divide el numero 0000000,00 -> entero y decimal
            String[] Num = numero.Split(',');

            //de da formato al numero decimal
            parte_decimal = " con " + Num[1] + "/100 Bolivianos.";
            //se convierte el numero a literal
            if (int.Parse(Num[0]) == 0)
            {//si el valor es cero                
                literal = "cero ";
            }
            else if (int.Parse(Num[0]) > 999999)
            {//si es millon
                literal = getMillones(Num[0]);
            }
            else if (int.Parse(Num[0]) > 999)
            {//si es miles
                literal = getMiles(Num[0]);
            }
            else if (int.Parse(Num[0]) > 99)
            {//si es centena
                literal = getCentenas(Num[0]);
            }
            else if (int.Parse(Num[0]) > 9)
            {//si es decena
                literal = getDecenas(Num[0]);
            }
            else
            {//sino unidades -> 9
                // literal = getUnidades(Num[0]);
            }
            //devuelve el resultado en mayusculas o minusculas
            if (mayusculas)
            {
                return (literal + parte_decimal).ToUpper();
            }
            else
            {
                return (literal + parte_decimal);
            }

        }
    }


}
