using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;
using System.Windows.Forms.ComponentModel;


namespace BuscaExec
{
    public partial class Main : Form
    {

        #region //========================= V A R I A V E I S ======================================//

        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString,
        int nSize, string lpFileName);

        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);
       
        //Variaveis
        private static string vsLocal = Environment.CurrentDirectory;
        private static FileInfo[] oFileLogin = new DirectoryInfo(vsLocal).GetFiles("*C5_Login.ini", SearchOption.AllDirectories);
        string arquivo = oFileLogin[0].FullName;
        string[] vaModulo;
        string[] vaVersao;
        string[] vaMapeamento;
        FileStream fsConfig = default(FileStream);
        StreamReader rsConfig = default(StreamReader);
        string vsOrigem = null;
        string vsDestino = null;
        string vsCaminhoExec = null;
        string vsModulo = null;
        string vsCaminhoDel = null;
        string vsArquivoDel = null;
        

        class Item
        {
            public string Display { get; set; }
            public string Value { get; set; }
        }

        List<Item> lstVersao = new List<Item>();
        List<Item> lstMapeamento = new List<Item>();

        #endregion

        #region //========================= M E T O D O S  ==========================================//
        public Main()
        {
            InitializeComponent();
            this.CarregaGrid();
            this.CarregaList();
            this.InicializaCampos();
            

        }

        private void CarregaGrid()
        {

            if (File.Exists(arquivo))
            {

                try
                {
                    //Setando valores
                    fsConfig = new FileStream(arquivo, FileMode.Open, FileAccess.Read);
                    rsConfig = new StreamReader(fsConfig);
                    string strLinha = null;
                    bool bCarregaModulo = false;
                    bool bCarregaVersao = false;
                    bool bCaminho = false;
                    bool bMapeamento = false;
                    

                    //Lê o arquivo .INI
                    while (rsConfig.Peek() != -1)
                    {
                        strLinha = rsConfig.ReadLine();

                        if (strLinha.Length > 0)
                        {
                            // busca o modulo
                            if (strLinha.Contains("["))
                            {
                                if (strLinha.Contains("[MODULO]"))
                                {
                                    bCarregaModulo = true;
                                    bCarregaVersao = false;
                                    bCaminho = false;
                                    bMapeamento = false;

                                }
                                else if (strLinha.Contains("[VERSAO]"))
                                {
                                    bCarregaVersao = true;
                                    bCarregaModulo = false;
                                    bCaminho = false;
                                    bMapeamento = false;

                                }
                                else if (strLinha.Contains("[EXE]"))
                                {
                                    bCarregaVersao = false;
                                    bCarregaModulo = false;
                                    bCaminho = true;
                                    bMapeamento = false;
                                }
                                else if (strLinha.Contains("[MAPEAMENTO]"))
                                {
                                    bCarregaModulo = false;
                                    bCarregaVersao = false;
                                    bCaminho = false;
                                    bMapeamento = true;
                                }
                            }

                            //Modulo
                            if (bCarregaModulo == true && (strLinha.Contains("[MODULO]") == false))
                            {
                                vaModulo = strLinha.Split('@');
                                string[] row = { vaModulo[0], vaModulo[1] };
                                this.dgvModulo.Rows.Add(row);

                            }

                            //Versao
                            if (bCarregaVersao == true && (strLinha.Contains("[VERSAO]") == false))
                            {
                                vaVersao = strLinha.Split('@');

                                lstVersao.Add(new Item { Display = vaVersao[0], Value = vaVersao[1] });

                            }

                            // caminho
                            if (bCaminho == true && (strLinha.Contains("[EXE]") == false))
                            {
                                if (vsOrigem == null)
                                {
                                    vsOrigem = strLinha;
                                }
                                else if (vsDestino == null)
                                {
                                    vsDestino = strLinha;
                                }
                            }

                            // Mapeamenot
                            if (bMapeamento == true && (strLinha.Contains("[MAPEAMENTO]") == false))
                            {
                                vaMapeamento = strLinha.Split('@');

                                this.lstMapeamento.Add(new Item { Display = vaMapeamento[0], Value = vaMapeamento[1] });

                            }
                        }
                    }

                    // Carregando as Combox
                    this.cboVersao.DataSource = lstVersao;
                    this.cboVersao.DisplayMember = "Display";
                    this.cboVersao.ValueMember = "Value";
                    //
                    this.cboMapeamento.DataSource =lstMapeamento;
                    this.cboMapeamento.DisplayMember = "Display";
                    this.cboMapeamento.ValueMember = "Value";

                    this.dgvModulo.Sort(this.dgvModulo.Columns[0], ListSortDirection.Ascending);
                   

                }
                catch (Exception ex)
                {
                    throw new ArgumentException("ERRO", "Não foi possivel carregar a tela, Erro:" + ex);
                    
                };
            } 
            else 
            {
                 MessageBox.Show("Arquivo 'Login' não existe", "ATENÇÂO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool CopiaArquivos(string pOrigem, string pDestino, string pCaminhoExec)
        {
            //Variaveis
            vsArquivoDel = null;
            vsCaminhoDel = null;

            //Verifica se Arquivo Existe
            if (Directory.Exists(pOrigem) == false)
            {
                MessageBox.Show("Diretorio de Origem não existe", "ATENÇÂO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            
            // procurando arquivo
            FileInfo[] oFile = new DirectoryInfo(pOrigem).GetFiles(pCaminhoExec, SearchOption.AllDirectories);
          
            //Setando Caminho
            pOrigem = oFile[0].FullName;
            pDestino = pDestino + '\\' + oFile[0].Name;
          
            //Verifica se o Arquivo de Origem existe
            if (File.Exists(pOrigem) == false)
            {
                MessageBox.Show("Arquivo de Origem não existe", "ATENÇÂO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            
            // verifica se o arquivo ZIP existe e deleta
            if (File.Exists(pDestino) == true)
            {
                // deleta o arquivo
                File.Delete(pDestino);
            }

            try
            {
                //Copiando Arquivos
                oFile[0].CopyTo(pDestino);

            Inicio:
                // ==============================     
                try
                {
             
                    //Descompactando                
                    ZipFile.ExtractToDirectory(pDestino, vsDestino);
                }
                catch (Exception)
                {
                    // procurando arquivo
                    FileInfo[] oFileDel = new DirectoryInfo(vsDestino).GetFiles("*.exe", SearchOption.AllDirectories);
                    
                    //Carregando a Imagem
                    vsArquivoDel = vsCaminhoExec.Replace("*","");

                    // percorre a pasta com todos os exe
                    for (int x = 0; x < oFileDel.Count(); x++)
                    {
                        // se achou o exec que procura
                        if (oFileDel[x].FullName.ToLower().Contains(vsArquivoDel.ToLower()))
                        {
                            //deleta o exec encontrado
                            vsCaminhoDel = oFileDel[x].FullName;
                            File.Delete(vsCaminhoDel);
                            break;
                        }
                    }

                    // Voltando para tentar descompactar
                    goto Inicio;
                    
                }
             

                //Carregando Lista
                this.CarregaList();

                //Da a mensagem de execução
                MessageBox.Show("Arquivo copiado e atualizado com sucesso!", "Atualização", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.txtRelease.Text = null;
                return true;
            }
            catch (Exception ex)
            {
                
                
                MessageBox.Show("Erro ao copiar o arquivo: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
        }

        private void InicializaCampos()
        {
            if (this.cboVersao.Items.Count > 0)
            {
                this.cboVersao.SelectedIndex = 0;
            }
        }

       
        private void RowAtivo()
        {
            if (dgvModulo.CurrentRow != null)
            {
                if (dgvModulo.CurrentRow.Cells["CODIGO"].Value.ToString() != null)
                {
                    vsCaminhoExec = "*" + dgvModulo.CurrentRow.Cells["CODIGO"].Value.ToString();
                    vsModulo = dgvModulo.CurrentRow.Cells["DESCRICAO"].Value.ToString();
                }
            }
        }

        private void CarregaList()
        {

            //Seta diretorio
            DirectoryInfo Dir = new DirectoryInfo(vsDestino);

            // Busca automaticamente todos os arquivos em todos os subdiretórios
            FileInfo[] Files = Dir.GetFiles("*.exe", SearchOption.AllDirectories);

            //Limpando a lista
            lstExec.Items.Clear();

            foreach (FileInfo File in Files)
            {
                
                // Retira o diretório iformado inicialmente
                string FileName = File.FullName.Replace(Dir.FullName, "").Remove(0, 1);

                // se achou o exec que procura
                lstExec.Items.Add(FileName);
            }

            // seleciona item lista
            if(vsArquivoDel == null) 
            {
                // caso não exista arquivo extraido busca o primeiro
                lstExec.SetSelected(0, true);
            }
            else
            {
                // força selecionar o item que foi extraido -- 
                for (int i = 0; i < lstExec.Items.Count; i++)
                {
                    if (lstExec.Items[i].ToString().ToLower().StartsWith(vsArquivoDel.ToLower()))
                    {
                        lstExec.SetSelected(i, true);
                        break;
                    }

                }
            }

            lstExec.Sorted = true;
          
        }

        private bool Executando()
        {
            if (lstExec.Items.Count == 0)
            {
                MessageBox.Show("Nenhum executavel disponivel!", "Executaveis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            var sExecuta =  lstExec.SelectedItem.ToString();
            var sPath = vsDestino;

            // procurando arquivo
            FileInfo[] oDir = new DirectoryInfo(sPath).GetFiles(sExecuta, SearchOption.AllDirectories);

            //Setando Caminho
            string sCaminhoExec = oDir[0].FullName;

            if (sCaminhoExec == string.Empty)
            {
                MessageBox.Show("Nenhum executavel disponivel!", "Executaveis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                //Executa
                System.Diagnostics.Process.Start(sCaminhoExec);
                return true;
            }

        }

        private bool Atualiza()
        {
            if (this.txtRelease.Text.ToString() == string.Empty)
            {
                MessageBox.Show("Release não foi informado!", "Atualização de Exec", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtRelease.Focus();
                return false;
            }

            this.RowAtivo();

            string sVersao = cboVersao.SelectedValue.ToString();

            int vnRelease = int.Parse(txtRelease.Text);
            string vsRelease = vnRelease.ToString("D3");

            string vsCaminhoExecZip = null;


            string vsOrigemNew = vsOrigem + '\\' + cboVersao.Text;
            vsCaminhoExecZip = vsCaminhoExec + '_' + sVersao + '_' + vsRelease;
            vsCaminhoExecZip = vsCaminhoExecZip + ".ZIP";

            if (CopiaArquivos(vsOrigemNew, vsDestino, vsCaminhoExecZip) == false)
            {
                MessageBox.Show("Não foi possivel copiar os arquivos.", "Copiando Arquivos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public bool Mapeamento()
        {
            string vsInput = "subst M: " + cboMapeamento.SelectedValue.ToString();
            //string vsInput1 = "subst m: /d";
            try
            {

                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                cmd.StandardInput.WriteLine("subst m: /d");
                cmd.StandardInput.WriteLine(vsInput);
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());

                MessageBox.Show("Mapeamento Efetuado com Sucesso!", "Mapeamento", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
           
            }
            catch (Exception ex)
            {

                throw new ArgumentException("ERROR", "Não foi possivel fazer o mapeamento, Erro:" + ex);
                
            }
        }

        public bool PesquisandoGrid(string pText)
        {
            
            int number = 0;
            if (pText != string.Empty) 
            {
                foreach (DataGridViewRow row in dgvModulo.Rows)
                {
                    //percorre a linha
                    foreach (DataGridViewCell item in dgvModulo.Rows[row.Index].Cells)
                    {
                        if (item.ColumnIndex == number)
                        {
                           // item.Value.ToString().ToLower;
                            if (item.Value.ToString().ToUpper().Contains(pText.ToUpper()))
                            {
                                this.dgvModulo.Rows[row.Index].Visible = true;
                            }
                            else
                            {
                                this.dgvModulo.Rows[row.Index].Visible = false;
                            }
                        }
                    }
                    
                }


            }
            else
            {
                foreach (DataGridViewRow row in dgvModulo.Rows)
                {
                    //percorre a linha
                    foreach (DataGridViewCell item in dgvModulo.Rows[row.Index].Cells)
                    {
                        this.dgvModulo.Rows[row.Index].Visible = true;
                    }

                }
            }
            return true;

        }

        public bool Limpar()
        {
            try
            {
                // procurando arquivo
                FileInfo[] oFileDel = new DirectoryInfo(vsDestino).GetFiles("*.exe", SearchOption.AllDirectories);

                //Carregando a Imagem
                vsArquivoDel = vsCaminhoExec.Replace("*", "");

                // percorre a pasta com todos os exe
                for (int x = 0; x < oFileDel.Count(); x++)
                {
                    //deleta o exec encontrado
                    vsCaminhoDel = oFileDel[x].FullName;
                    File.Delete(vsCaminhoDel);
                    break;

                }

                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao Limpar o arquivo: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
        }

        #endregion//==================================================================================//



        #region//============================== BUSCA INFORMAÇÕES O INI ==========================//
        public static string GetIniValue(string section, string key, string nomeArquivo)
         {
             int chars = 256;
             StringBuilder buffer = new StringBuilder(chars);
             string sDefault = "";
             if (GetPrivateProfileString(section, key, sDefault, buffer, chars, nomeArquivo) != 0)
             {
                 return buffer.ToString();
             }
             else
             {
                 // Verifica o último erro Win32.
                 int err = Marshal.GetLastWin32Error();
                 return null;
             }
         }

        public string getCaminhoArquivoINI(string caminhoArquivo)
        {
            if (caminhoArquivo.IndexOf("\\bin\\Debug") != -1)
            {
                caminhoArquivo = caminhoArquivo.Replace("\\bin\\Debug", "");
            }
            else if (caminhoArquivo.IndexOf("\\bin\\Release") != -1)
            {
                caminhoArquivo = caminhoArquivo.Replace("\\bin\\Release", "");
            }

            return caminhoArquivo;
        }

        public void LereGravarArquivo(Boolean pbVersao)
        {
            string arquivo = @"C:\C5_Login.ini";

            if (File.Exists(arquivo))

            {

                try

                {

                    using (StreamReader sr = new StreamReader(arquivo))

                    {

                        String linha;

                        // Lê linha por linha até o final do arquivo

                        while ((linha = sr.ReadLine()) != null)

                        {
                            if (linha.Contains("[VERSAO]") && pbVersao == true)
                            {
                                    break;
                            }

                        }

                    }

                }

                catch (Exception ex)

                {

                    //Console.WriteLine(ex.Message);
                    MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }

            else

            {

                Console.WriteLine(" O arquivo " + arquivo + "não foi localizado !");
            }
        }

        #endregion//===============================================================================//


        #region//======================== E V E N T O S =======================================//
        private void btnAtualiza_Click(object sender, EventArgs e)
        {
            this.Atualiza();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                this.Atualiza();
            }
            if (e.KeyCode == Keys.F5)
            {
                this.Executando();
            }
            if (e.KeyCode == Keys.F6)
            {
                this.Mapeamento();
            }
            if (e.KeyCode == Keys.F10)
            {
                this.Limpar();
            }
            if (e.Control == true && e.KeyCode == Keys.V)
            {
                this.cboVersao.Focus();
            }
            if (e.Control == true && e.KeyCode == Keys.R)
            {
                this.txtRelease.Focus();
            }
            if (e.Control == true && e.KeyCode == Keys.M)
            {
                this.cboMapeamento.Focus();
            }
        }

        private void dgvModulo_Click(object sender, EventArgs e)
        {
            this.RowAtivo();
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            this.Executando();
                      
        }

        private void txtVersao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.'))
            {

                e.Handled = true;

            }
        }

        private void txtRelease_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) //&& (e.KeyChar != '.')
            {

                e.Handled = true;

            }
        }

        private void btnMapeamento_Click(object sender, EventArgs e)
        {
            this.Mapeamento();
        }

        private void mnuLocalOrigem_Click(object sender, EventArgs e)
        {
            //se existir caminho de origem
            if (vsOrigem != null)
            {
                Process.Start("Explorer", vsOrigem);
            }
        }

        private void mnuLocalDestino_Click(object sender, EventArgs e)
        {
            //se existir caminho de Destino
            if (vsDestino != null)
            {
                Process.Start("Explorer", vsDestino);
            }
        }

        private void mnuSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPesquisaModulo_TextChanged(object sender, EventArgs e)
        {
            string vsFiltro = this.txtPesquisaModulo.Text.ToString();

            this.PesquisandoGrid(vsFiltro);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.Limpar();
        }


        #endregion//================== F I M - - - E V E N T O S =================================//

       



     






      



       

    }
}
