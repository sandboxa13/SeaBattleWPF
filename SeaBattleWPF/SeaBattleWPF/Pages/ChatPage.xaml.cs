using System.Windows.Controls;

namespace SeaBattleWPF.Pages
{
    /// <summary>
    /// Interaction logic for ChatPage.xaml
    /// </summary>
    public partial class ChatPage 
    {
        public ChatPage()
        {
            InitializeComponent();

            listView.Items.Add(new MyItem { Nick = "COx", Message = "sdfsdfsdfsdf sd fsd fsd fsd fsd fsdfsdfs" });
            listView.Items.Add(new MyItem { Nick = "COx", Message = "sdfsdfsdfsdf sd fsd fsd fsd fsd fsdfsdfs" });
            listView.Items.Add(new MyItem { Nick = "COx", Message = "sdfsdfsdfsdf sd fsd fsd fsd fsd fsdfsdfs" });
            listView.Items.Add(new MyItem { Nick = "COx", Message = "sdfsdfsdfsdf sd fsd fsd fsd fsd fsdfsdfs" });
            listView.Items.Add(new MyItem { Nick = "COx", Message = "sdfsdfsdfsdf sd fsd fsd fsd fsd fsdfsdfs" });
            listView.Items.Add(new MyItem { Nick = "COx", Message = "sdfsdfsdfsdf sd fsd fsd fsd fsd fsdfsdfs" });
            listView.Items.Add(new MyItem { Nick = "COx", Message = "sdfsdfsdfsdf sd fsd fsd fsd fsd fsdfsdfs" });
            listView.Items.Add(new MyItem { Nick = "COx", Message = "sdfsdfsdfsdf sd fsd fsd fsd fsd fsdfsdfs" });
            listView.Items.Add(new MyItem { Nick = "COx", Message = "sdfsdfsdfsdf sd fsd fsd fsd fsd fsdfsdfs" });
        }
    }
    public class MyItem
    {
        public string Nick { get; set; }

        public string Message { get; set; }
    }
}
