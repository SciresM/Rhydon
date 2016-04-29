using System.Windows.Forms;

namespace Rhydon.SAV
{
    public partial class SAV_Options : Form
    {

        private readonly SAV1 sav;
        public SAV_Options(ref SAV1 source)
        {
            InitializeComponent();

            sav = source;

            CB_BattleStyle.Items.AddRange(new[] {"Switch", "Set"});
            CB_SoundType.Items.AddRange(new[] {"Mono", "Stereo", "Earphone2", "Earphone3"});
            CB_TextSpeed.Items.AddRange(new[] {"0 (Instant)", "1 (Fast)", "2", "3 (Normal)", "4", "5 (Slow)", "6", "7" });

            CHK_BattleEffects.Checked = sav.BattleEffects;
            CB_BattleStyle.SelectedIndex = sav.BattleStyleSwitch ? 0 : 1;
            CB_SoundType.SelectedIndex = sav.Sound;
            CB_TextSpeed.SelectedIndex = sav.TextSpeed;
        }

        private void Cancel(object sender, System.EventArgs e)
        {
            Close();
        }

        private void Save(object sender, System.EventArgs e)
        {
            sav.BattleEffects = CHK_BattleEffects.Checked;
            sav.BattleStyleSwitch = CB_BattleStyle.SelectedIndex == 0;
            sav.Sound = CB_SoundType.SelectedIndex;
            sav.TextSpeed = CB_TextSpeed.SelectedIndex;
            Close();
        }
    }
}
