using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMC.BusinessObjects
{
   public class Validaciones
    {
       public static int n, l;
        public void validar(object sender, KeyPressEventArgs e, int parametro, TextBox tBox1)
        {
            #region validar Numeros Enteros
            if (parametro == 1)
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            #endregion

            #region validar Letras
            else  if(parametro==2){ //si el parametro es 2 validamos letras
            if (Char.IsLetter(e.KeyChar)) //verificamos si es un caracter
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //verificamos si se trata de la tecla backspace
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar)) //verificamos si es la tecla de separador
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            }
            #endregion


            #region Validar Decimales
            else if (parametro == 3)
            {
                if (((e.KeyChar) < 48) && ((e.KeyChar) != 8) || ((e.KeyChar) > 57))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '.')
                    e.KeyChar = ',';
                //Permitir comas y puntos (si es punto )
                if (e.KeyChar == ',' || e.KeyChar == '.')
                    //si ya hay una coma no permite un nuevo ingreso de esta
                    if (tBox1.Text.Contains(",") || tBox1.Text.Contains("."))
                        e.Handled = true;
                    else
                        e.Handled = false;
            }
            #endregion

            #region Limitar Caracteres
            else if (parametro == 4)
            {
                if (tBox1.Text.Length == 7)
                {
                    foreach (char c in tBox1.Text)
                    {
                        if (char.IsNumber(c)) n += 1;
                        if (char.IsLetter(c)) l += 1;
                    }
                    if (n == 4 && l == 3) tBox1.Text = "validado";
                   // else tBox1.Text = "NO validado";
                }
                //else tBox1.Text = "NO validado";
            }
            #endregion
            #region Validar Alfanumericos 
            else if (parametro == 5)
            { 
                if (Char.IsLetter(e.KeyChar) || Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)
                    || Char.IsSeparator(e.KeyChar))  
             
                {
                    e.Handled = !true;
                }
                
                    else
                        e.Handled = !false;
            }
            #endregion
        }
    }
}
