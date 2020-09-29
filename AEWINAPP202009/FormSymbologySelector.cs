using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using System.Windows.Forms;

namespace AEWINAPP202009
{
    public partial class FormSymbologySelector : Form
    {
        IStyleGalleryItem m_pStyleGalleryItem;
        FormMainOperation m_FrmMainOper;
        public FormSymbologySelector(FormMainOperation formMainOperation, esriSymbologyStyleClass esriSymbologyStyleClass)
        {
            InitializeComponent();
            m_FrmMainOper = formMainOperation;
            Ctrl_Symbology.StyleClass = esriSymbologyStyleClass;
            Ctrl_Symbology.Refresh();
        }

        private void Ctrl_Symbology_OnItemSelected(object sender, ESRI.ArcGIS.Controls.ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            m_pStyleGalleryItem = (IStyleGalleryItem)e.styleGalleryItem;
        }

        private void Ctrl_Symbology_OnDoubleClick(object sender, ISymbologyControlEvents_OnDoubleClickEvent e)
        {
            m_FrmMainOper(OperationType.SentStyleGalleryItem, m_pStyleGalleryItem);
            this.Close();
        }
    }
}
