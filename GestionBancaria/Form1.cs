namespace GestionBancaria
{
    public partial class Form1 : Form
    {
        private double saldo_Ppv_2023 = 1000;  // Saldo inicial de la cuenta, 1000€

        public Form1()
        {
            InitializeComponent();
            txtSaldo.Text = saldo_Ppv_2023.ToString();
            txtCantidad.Text = "0";
        }

        private void realizarReintegro(double cantidad)
        {
            if (cantidad > 0 && saldo_Ppv_2023 >= cantidad)
            {
                saldo_Ppv_2023 -= cantidad;
            }
        }

        private void realizarIngreso(double cantidad)
        {
            if (cantidad >= 0)
                saldo_Ppv_2023 += cantidad;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double cantidad = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (cantidad < 0)
            {
                MessageBox.Show("Cantidad no válida, sólo se admiten cantidades positivas.");
            }
            else
            {
                if (rbReintegro.Checked)
                {
                    realizarReintegro(cantidad);
                    txtSaldo.Text = saldo_Ppv_2023.ToString();
                }// No se ha podido completar la operación, saldo insuficiente?
                    

                if (rbIngreso.Checked)
                {
                    realizarIngreso(cantidad);
                    txtSaldo.Text = saldo_Ppv_2023.ToString();
                }
            }
            if (double.Parse(txtSaldo.Text) < cantidad)
                MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
        }
       
    }
}