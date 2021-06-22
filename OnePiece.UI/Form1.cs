using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OnePiece.Business.Abstract;
using OnePiece.Business.DependencyResolvers.Ninject;
using OnePiece.Entities.Database;
using OnePiece.Entities.Dtos;

namespace OnePiece.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ICharacterService _characterService = InstanceFactory.GetInstance<ICharacterService>();
        private ITayfaService _tayfaService = InstanceFactory.GetInstance<ITayfaService>();
        private IImageService _imageService = InstanceFactory.GetInstance<IImageService>();
      

        public void Listele()
        {
            //var model = _characterService.GetAll();

            // dataGridView1.DataSource = model;

            var model2 = _characterService.GetirCharacterTayfaIle();

            List<CharacterModel> models = new List<CharacterModel>();
            foreach (var o in model2)
            {
                models.Add(new CharacterModel
                {
                    CharacterId = o.CharacterId,
                    CharacterName = o.CharacterName,
                    CharacterPower = o.CharacterPower,
                    TayfaName = o.Tayfalar.TayfaName
                });
            }



            //var getir = (from c in model2
            //             from i in c.Images

            //             select new CharacterModel
            //             {
            //                 CharacterId = c.CharacterId,
            //                 CharacterName = c.CharacterName,
            //                 CharacterPower = c.CharacterPower,
            //                 TayfaName = c.Tayfalar.TayfaName,
            //                 Resims = i.ImageUrl
            //             }).ToList();

            //var olurP = model2.SelectMany(x => x.Images);

            dataGridView1.DataSource = models;
 



            //foreach (var m in model2)
            //{


            //    var yeni = new CharacterModel
            //    {

            //        //Resims = m.Images.
            //        CharacterId = m.CharacterId,
            //        CharacterName = m.CharacterName,
            //        CharacterPower = m.CharacterPower,
            //        TayfaName = m.Tayfalar.TayfaName,



            //    };
            //    models.Add(yeni);
            //}

            //dataGridView1.DataSource = models;

            cbxTayfa.DataSource = _tayfaService.GetAll();

            cbxTayfa.DisplayMember = "TayfaName";
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            var select = textBox3.Text;
            var bu = _characterService.HakiKullananKarakterler(x => x.CharacterPower == select);
            dataGridView1.DataSource = bu;
        }

        private void CharacterAdd_Click(object sender, EventArgs e)
        {
            _characterService.Add(new Entities.Database.Character
            {
                CharacterName = txtName.Text,
                CharacterPower = txtPower.Text,
                TayfaId = cbxTayfa.SelectedIndex+1
            });
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _tayfaService.Add(new Tayfalar { TayfaName = txtTayfaName.Text });
            Listele();
            txtTayfaName.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            txtResimUrl.Text = openFileDialog1.FileName;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var selector = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                var imgList = _imageService.GetAll().Where(x => x.CharacterId == selector).ToList();
                dataGridView2.DataSource = imgList;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var tayfa = _tayfaService.GetAll();
            if (dataGridView1.CurrentRow != null)
            {
                var model2 = _characterService.GetirCharacterTayfaIle();

                List<CharacterModel> models = new List<CharacterModel>();
                foreach (var o in model2)
                {
                    models.Add(new CharacterModel
                    {
                        CharacterId = o.CharacterId,
                        CharacterName = o.CharacterName,
                        CharacterPower = o.CharacterPower,
                        TayfaName = o.Tayfalar.TayfaName
                    });
                }
         
                var selector = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                var imgList = _imageService.GetAll().Where(x => x.CharacterId == selector).ToList();
                var uptadeItem = models.Where(x => x.CharacterId == selector).ToList();
                var tayfaId = cbxTayfa.SelectedIndex;
                DetailFormUpdate frm = new DetailFormUpdate(selector, imgList, uptadeItem, tayfa, _characterService);
                this.Hide();
                frm.ShowDialog();

           




            }

        }
    }

}
