using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class FormFichaDeIngreso_941lp : Form
    {
        bllCedente_941lp bllCedente_941lp;
        bllRegistroAnimales_941lp bllAnimal_941lp;
        bllFichaIngreso_941lp bllFichaIngreso_941;
        FormRegistroAnimales_941lp formRegistroAnimales_941lp;
        FormGestorCedentes_941lp formGestorCedentes_941lp;
        ModoOperacion_941lp modo_941lp;
        public FormFichaDeIngreso_941lp()
        {
            InitializeComponent();
            bllAnimal_941lp = new bllRegistroAnimales_941lp();
            bllCedente_941lp = new bllCedente_941lp();
            bllFichaIngreso_941 = new bllFichaIngreso_941lp();
            formRegistroAnimales_941lp = new FormRegistroAnimales_941lp();
            formGestorCedentes_941lp = new FormGestorCedentes_941lp();
            modo_941lp = ModoOperacion_941lp.Consulta;
        }

        private void FormFichaDeIngreso_941lp_Load(object sender, EventArgs e)
        {
            dataCedentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataCedentes.MultiSelect = false;
            dataCedentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MostrarGrillaCedentes_941lp(bllCedente_941lp.RetornarCedentes_941lp());
            dataAnimales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataAnimales.MultiSelect = false;
            dataAnimales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            listViewFichas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            MostrarDataAnimales_941lp(bllAnimal_941lp.RetornarAnimales_941lp());
            MostrarFichasIngreso_941lp(bllFichaIngreso_941.RetornarFichas_941lp(), " ");
            HabilitarGrillas(false);
            ModoAceptarCancelar_941lp();
            AjustarColumnasListView_941lp();
        }

        private void AjustarColumnasListView_941lp()
        {
            int anchoTotal = listViewFichas.ClientSize.Width;
            int cantidadColumnas = listViewFichas.Columns.Count;
            int anchoPorColumna = anchoTotal / cantidadColumnas;

            foreach (ColumnHeader col in listViewFichas.Columns)
            {
                col.Width = anchoPorColumna;
            }
        }

        private void HabilitarGrillas(bool habilitar_941lp)
        {
            dataAnimales.Enabled = habilitar_941lp;
            dataCedentes.Enabled = habilitar_941lp;
        }

        private void CargarTxt_941lp()
        {
            if (listViewFichas.SelectedItems.Count > 0 && modo_941lp != ModoOperacion_941lp.Alta)
            {
                var item = listViewFichas.SelectedItems[0];
                txtRazon.Text = item.SubItems[6].Text;
                txtZona.Text = item.SubItems[7].Text;
            }
        }

        private void MostrarFichasIngreso_941lp(List<FichaDeIngreso_941lp> listaFichas_941lp, string identificador_941lp)
        {
            listViewFichas.Items.Clear();

            IEnumerable<FichaDeIngreso_941lp> fichasFiltradas_941lp;

            if (rbCedente.Checked)
            {
                fichasFiltradas_941lp = listaFichas_941lp.Where(a => a.dni_941lp == identificador_941lp);
            }
            else if (rbAnimal.Checked)
            {
                fichasFiltradas_941lp = listaFichas_941lp.Where(a => a.codigoAnimal_941lp == Convert.ToInt32(identificador_941lp));
            }
            else
            {
                fichasFiltradas_941lp = listaFichas_941lp;
            }

            foreach (var ficha in fichasFiltradas_941lp)
            {
                var item = new ListViewItem(ficha.codigo_941lp.ToString());
                item.SubItems.Add($"{ficha.codigoAnimal_941lp}");
                item.SubItems.Add(ficha.dni_941lp);
                item.SubItems.Add(ficha.especie_941lp);
                item.SubItems.Add(ficha.fecha_941lp.ToString("dd/MM/yyyy"));
                item.SubItems.Add(ficha.hora_941lp.ToString(@"hh\:mm\:ss"));
                item.SubItems.Add(ficha.razon_941lp);
                item.SubItems.Add(ficha.zona_941lp);
                listViewFichas.Items.Add(item);
            }
        }

        enum ModoOperacion_941lp
        {
            Consulta,
            Alta,
            Modificar
        }

        private void MostrarDataAnimales_941lp(List<Animal_941lp> animalLista_941lp)
        {
            dataAnimales.Rows.Clear();
            // Mostrar en la grilla
            foreach (Animal_941lp a_941lp in animalLista_941lp)
            {
                if(a_941lp.estadoAdopcion_941lp != "Adoptado")
                {
                    int rowIdex_941lp = dataAnimales.Rows.Add(a_941lp.codigoAnimal_941lp,a_941lp.especie_941lp,a_941lp.raza_941lp,a_941lp.nombre_941lp,a_941lp.tamaño_941lp,a_941lp.sexo_941lp,a_941lp.estadoAdopcion_941lp,a_941lp.vivo_941lp);
                    if(a_941lp.vivo_941lp == false)
                    {
                        dataAnimales.Rows[rowIdex_941lp].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void MostrarGrillaCedentes_941lp(List<Cedente_941lp> cedentesLista_941lp)
        {
            dataCedentes.Rows.Clear();
            if (cedentesLista_941lp != null)
            {
                foreach (Cedente_941lp c_941lp in cedentesLista_941lp)
                {
                    int rowIndex_941lp = dataCedentes.Rows.Add(c_941lp.dni_941lp, c_941lp.nombre_941lp, c_941lp.apellido_941lp, c_941lp.direccion_941lp, c_941lp.telefono_941lp, c_941lp.activo_941lp);
                    if(c_941lp.activo_941lp == false)
                    {
                        dataCedentes.Rows[rowIndex_941lp].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnCrearFichaDeIngreso_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataAnimales.Rows.Count == 0) throw new Exception("No hay animales a los que hacerle la ficha de ingreso");
                DialogResult drAnimal_941lp = MessageBox.Show("¿Nuevo animal?", "Generar ficha médica", MessageBoxButtons.YesNo);
                if(drAnimal_941lp == DialogResult.Yes)
                {
                    formRegistroAnimales_941lp.ShowDialog();
                }
                DialogResult drCedente_941lp = MessageBox.Show("¿Nuevo cedente?", "Generar ficha médica", MessageBoxButtons.YesNo);
                if (drCedente_941lp == DialogResult.Yes)
                {
                    formGestorCedentes_941lp.ShowDialog();
                }
                if (drAnimal_941lp == DialogResult.No && drCedente_941lp == DialogResult.No)
                {
                    modo_941lp = ModoOperacion_941lp.Alta;
                    HabilitarTxt_941lp(true);
                    VisibilidadDeBotones_941lp();
                    HabilitarGrillas(true);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private void HabilitarTxt_941lp(bool habilitar_941lp)
        {
            if (modo_941lp == ModoOperacion_941lp.Alta || modo_941lp == ModoOperacion_941lp.Modificar)
            {
                txtRazon.Enabled = habilitar_941lp;
                txtZona.Enabled = habilitar_941lp;
            }
            else
            {
                txtRazon.Enabled = !habilitar_941lp;
                txtZona.Enabled = !habilitar_941lp;
            }
            AplicarColorControles_941lp();
        }

        private void VisibilidadDeBotones_941lp()
        {
            btnCrearFichaDeIngreso.Enabled = false;
            btnModificarFichaMedica.Enabled = false;
            btnSalir.Enabled = false;
            btnCancelar.Enabled = true;
            btnAplicar.Enabled = true;
            dataAnimales.Enabled = true;
            dataCedentes.Enabled = true;
            AplicarColorControles_941lp();
        }

        private void AplicarColorControles_941lp()
        {
            var controles_941lp = new Control[]
            {
                txtZona, txtRazon, btnCancelar, btnAplicar, btnCrearFichaDeIngreso, btnModificarFichaMedica, btnSalir
            };

            foreach (var control_941lp in controles_941lp)
            {
                if (control_941lp.Enabled == false)
                {

                    control_941lp.BackColor = Color.LightSteelBlue;
                }
                else
                {
                    control_941lp.BackColor = Color.White;
                }
            }
        }

        private void ControlDeIngresoDeDatos_941lp(string razon_941lp, string zona_941lp)
        {
            try
            {
                var regexTexto_941lp = new Regex(@"^[A-Za-zÁÉÍÓÚáéíóúÑñÜü\s]+$");
                if (!regexTexto_941lp.IsMatch(razon_941lp))
                    throw new ArgumentException("La razón ingresada es inválida. Solo se permiten letras y espacios.");
                if (!regexTexto_941lp.IsMatch(zona_941lp))
                    throw new ArgumentException("La zona ingresada es inválida. Solo se permiten letras y espacios.");
            }
            catch (ArgumentException ex)
            {
                throw new Exception($"Error de validación: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error inesperado durante la validación de datos.", ex);
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCargaDeTxt_941lp();
                ControlDeIngresoDeDatos_941lp(txtRazon.Text, txtZona.Text);
                string dni_941lp = dataCedentes.SelectedRows[0].Cells[0].Value.ToString();
                int codigoAnimal_941lp = Convert.ToInt32(dataAnimales.SelectedRows[0].Cells[0].Value);
                string especie_941lp = dataAnimales.SelectedRows[0].Cells[1].Value.ToString();
                switch (modo_941lp)
                {
                    case ModoOperacion_941lp.Alta:
                        if (bllFichaIngreso_941.VerificarCedenteActivo_941lp(dataCedentes.SelectedRows[0].Cells[0].Value.ToString())==false) throw new Exception("El cedente debe estar activo para generar una ficha de ingreso");
                        if (bllFichaIngreso_941.VerificarAnimalVivo_941lp(Convert.ToBoolean(dataAnimales.SelectedRows[0].Cells[7].Value)) == false) throw new Exception("El animal debe estar vivo para crear una ficha de ingreso");
                        bllAnimal_941lp.Modificar_941lp(codigo_941lp:dataAnimales.SelectedRows[0].Cells[0].Value.ToString(), estadoDeAdopcion_941lp : "En evaluacion");
                        bllFichaIngreso_941.Alta_941lp(codigoAnimal_941lp, dni_941lp,especie_941lp, DateTime.Now, DateTime.Now, txtRazon.Text, txtZona.Text);
                        MessageBox.Show("Ficha de ingreso generada exitosamente");
                        break;
                    case ModoOperacion_941lp.Modificar:
                        int codigo_941lp = Convert.ToInt32(listViewFichas.SelectedItems[0].SubItems[0].Text);
                        bllFichaIngreso_941.Modificar_941lp(codigo_941lp, txtRazon.Text, txtZona.Text);
                        MessageBox.Show("Ficha de ingreso modificada exitosamente");
                        break;
                    default:
                        MessageBox.Show("Error en la operación");
                        break;
                }
                ModoAceptarCancelar_941lp();
                MostrarFichasIngreso_941lp(bllFichaIngreso_941.RetornarFichas_941lp(), " ");
                MostrarDataAnimales_941lp(bllAnimal_941lp.RetornarAnimales_941lp());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ValidarCargaDeTxt_941lp()
        {
            if (string.IsNullOrWhiteSpace(txtRazon.Text) ||
                        string.IsNullOrWhiteSpace(txtZona.Text))
            {
                throw new Exception("Debe completar todos los campos obligatorios.");
            }
        }

        private void ModoAceptarCancelar_941lp()
        {
            modo_941lp = ModoOperacion_941lp.Consulta;
            btnAplicar.Enabled = false;
            btnCancelar.Enabled = false;
            btnCrearFichaDeIngreso.Enabled = true;
            btnModificarFichaMedica.Enabled = true;
            btnSalir.Enabled = true;
            dataAnimales.Enabled = false;
            dataCedentes.Enabled = false;
            AplicarColorControles_941lp();
            HabilitarTxt_941lp(true);
            LimpiarTxt_941lp();
        }

        private void LimpiarTxt_941lp()
        {
            foreach (Control c_941lp in this.Controls)
            {
                if (c_941lp is System.Windows.Forms.TextBox t_941lp)
                {
                    t_941lp.Text = "";
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Consulta;
                ModoAceptarCancelar_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dataAnimales.Enabled = false;
                dataCedentes.Enabled = false;
                MostrarFichasIngreso_941lp(bllFichaIngreso_941.RetornarFichas_941lp(), " ");
            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
        }

        private void rbCedente_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dataAnimales.Enabled = false;
                dataCedentes.Enabled = true;
                MostrarFichasIngreso_941lp(bllFichaIngreso_941.RetornarFichas_941lp(), dataCedentes.SelectedRows[0].Cells[0].Value.ToString());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void rbAnimal_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dataAnimales.Enabled = true;
                dataCedentes.Enabled = false;
                MostrarFichasIngreso_941lp(bllFichaIngreso_941.RetornarFichas_941lp(), dataAnimales.SelectedRows[0].Cells[0].Value.ToString());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataAnimales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MostrarFichasIngreso_941lp(bllFichaIngreso_941.RetornarFichas_941lp(), dataAnimales.SelectedRows[0].Cells[0].Value.ToString());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataCedentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MostrarFichasIngreso_941lp(bllFichaIngreso_941.RetornarFichas_941lp(), dataCedentes.SelectedRows[0].Cells[0].Value.ToString());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnModificarFichaMedica_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Modificar;
                HabilitarTxt_941lp(true);
                VisibilidadDeBotones_941lp();
                CargarTxt_941lp();
                HabilitarGrillas(false);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataAnimales_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MostrarFichasIngreso_941lp(bllFichaIngreso_941.RetornarFichas_941lp(), dataAnimales.SelectedRows[0].Cells[0].Value.ToString());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataCedentes_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MostrarFichasIngreso_941lp(bllFichaIngreso_941.RetornarFichas_941lp(), dataCedentes.SelectedRows[0].Cells[0].Value.ToString());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void listViewFichas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarTxt_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
