using OnePiece.Business.Abstract;
using OnePiece.Entities.Database;
using OnePiece.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OnePiece.UI
{
    public partial class DetailFormUpdate : Form
    {
        private readonly int _selector;
        private readonly List<Image> _imgList;
        private readonly List<CharacterModel> _uptadeItem;
        private readonly List<Tayfalar> _tayfa;
        private readonly ICharacterService _characterService;
        private readonly Form1 _form;
        public DetailFormUpdate(int selector, List<Image> imgList, List<CharacterModel> uptadeItem, List<Tayfalar> tayfa, ICharacterService characterService )
        {
            InitializeComponent();
            _selector = selector;
            _imgList = imgList;
            _uptadeItem = uptadeItem;
            _tayfa = tayfa;
            _characterService = characterService;
            _form = new Form1();
        }



        private void DetailFormUpdate_Load(object sender, EventArgs e)
        {

            foreach (var m in _uptadeItem)
            {
                txtPower.Text = m.CharacterPower;
                txtName.Text = m.CharacterName;
                comboBox1.DataSource = _tayfa;
                comboBox1.DisplayMember = "TayfaName";
                //Todo buraya seçili kategoriyi getirmeyi unutma!

            }
        }

        private void CharacterUpdate_Click(object sender, EventArgs e)
        {
            _characterService.Update(new Character
            {
                CharacterId = _selector,
                CharacterPower = txtPower.Text,
                CharacterName = txtName.Text,
                TayfaId = comboBox1.SelectedIndex + 1,
            });
            MessageBox.Show("karakter uptade");
            this.Hide();
            _form.ShowDialog();



        }
    }
}
