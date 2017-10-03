using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Homework4.Models;


namespace Homework4
{

	public partial class Homework4Page : ContentPage
    {
        protected  ObservableCollection<ListViewDataSource> originalListViewItems = new ObservableCollection<ListViewDataSource>();
		
        public Homework4Page()
        {
            InitializeComponent();

            populateListView();

        }

        private void populateListView()
        {
            var listViewItems = new ObservableCollection<ListViewDataSource>();

			var imageCell1 = new ListViewDataSource();
            imageCell1.ImageSource = "http://hvaskjeribaerum.no/wp-content/uploads/2017/01/DSC1185-862x573.jpg";
            imageCell1.ImageText = "Bærum";
            imageCell1.ImageDetailText = "Suburban area close to Oslo";
            imageCell1.ImageURL = "https://www.baerum.kommune.no/";
            imageCell1.Key = 1;

			var imageCell2 = new ListViewDataSource();
            imageCell2.ImageSource = "https://historiskeoslo.files.wordpress.com/2016/04/minde5.jpeg?w=1200&h=800&crop=1";
            imageCell2.ImageText = "Oslo";
            imageCell2.ImageDetailText = "Capital in Norway";
            imageCell2.ImageURL = "https://historiskeoslo.files.wordpress.com/2016/04/minde5.jpeg?w=1200&h=800&crop=1";
            imageCell2.Key = 2;

			var imageCell3 = new ListViewDataSource();
            imageCell3.ImageSource = "http://stavanger-forum.no/uploads/general/stavanger.jpg";
            imageCell3.ImageText = "Stavanger";
            imageCell3.ImageDetailText = "Coast city";
            imageCell3.ImageURL = "https://en.wikipedia.org/wiki/Stavanger";
            imageCell3.Key = 3;

			var imageCell4 = new ListViewDataSource();
            imageCell4.ImageSource = "https://res.cloudinary.com/simpleview/image/upload/c_fill,f_auto,h_258,q_64,w_380/v1/clients/norway/northern_lights_norway_norway_jan_a_pettersen_ac835526-60c9-4f0c-8085-6c0199632640.jpg";
            imageCell4.ImageText = "Narvik";
            imageCell4.ImageDetailText = "City in the north";
			imageCell4.ImageURL = "https://en.wikipedia.org/wiki/Narvik";
            imageCell4.Key = 4;

			var imageCell5 = new ListViewDataSource();
            imageCell5.ImageSource = "http://i0.wp.com/www.visitdrobak.no/wp-content/uploads/2012/03/Snekke-utfra-havna.ill_.jpg?resize=960%2C780";
            imageCell5.ImageText = "Droebak";
            imageCell5.ImageDetailText = "Many people in the capital have summer cottages here";
			imageCell5.ImageURL = "http://www.visitdrobak.no/";
            imageCell5.Key = 5;

			var imageCell6 = new ListViewDataSource();
            imageCell6.ImageSource = "http://www.lastminute.com/flights/lastminute/img/kristiansand.jpg";
            imageCell6.ImageText = "Kristiansand";
            imageCell6.ImageDetailText = "Summer city";
            imageCell6.ImageURL = "http://www.lastminute.com/flights/kristiansand/";
            imageCell6.Key = 6;

			var imageCell7 = new ListViewDataSource();
            imageCell7.ImageSource = "https://res.cloudinary.com/simpleview/image/upload/c_fill,f_auto,q_65,w_768/v1/clients/norway/b96d183a_ca51_437b_a585_db7bb6eafa57_8ae8e48d-2853-4674-9bb2-c43161d5a624.jpg";
            imageCell7.ImageText = "Bergen";
            imageCell7.ImageDetailText = "Rains a lot";
            imageCell7.ImageURL = "https://en.wikipedia.org/wiki/Bergen";
            imageCell7.Key = 7;

			var imageCell8 = new ListViewDataSource();
            imageCell8.ImageSource = "https://www.svalbardblues.com/wp-content/uploads/2015/09/Longyearbyen-Svalbard-Spitsbergen-DSB.jpg";
            imageCell8.ImageText = "Svalbard";
            imageCell8.ImageDetailText = "Very cold";
            imageCell8.ImageURL = "https://en.wikipedia.org/wiki/Svalbard";
            imageCell8.Key = 8;

            listViewItems.Add(imageCell1);
            listViewItems.Add(imageCell2);
            listViewItems.Add(imageCell3);
            listViewItems.Add(imageCell4);
            listViewItems.Add(imageCell5);
			listViewItems.Add(imageCell6);
            listViewItems.Add(imageCell7);
			listViewItems.Add(imageCell8);
            listView.ItemsSource = listViewItems;

			originalListViewItems.Add(imageCell1);
			originalListViewItems.Add(imageCell2);
			originalListViewItems.Add(imageCell3);
			originalListViewItems.Add(imageCell4);
			originalListViewItems.Add(imageCell5);
			originalListViewItems.Add(imageCell6);
			originalListViewItems.Add(imageCell7);
			originalListViewItems.Add(imageCell8);
        
        
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            var imageCell = (ImageCell)sender;
            var url = (string)imageCell.CommandParameter;
            Device.OpenUri(new System.Uri(url));
        }

        void Handle_Refreshing(object sender, System.EventArgs e)
        {
            listView.IsRefreshing = false;
			var col = (ObservableCollection<ListViewDataSource>)listView.ItemsSource;
            var tempListViewItems = new ObservableCollection<ListViewDataSource>();
            foreach(ListViewDataSource models in originalListViewItems){
                tempListViewItems.Add(models);
			}
            listView.ItemsSource = tempListViewItems;
		}

        protected int FindMahIndex(int key, ObservableCollection<ListViewDataSource> col)
        {
            int index = 0;

            foreach(ListViewDataSource element in col)
            {
                if (key == element.Key)
                    return index;

                index++;
            }

            return -1;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            MenuItem menI = (MenuItem)sender;
            int key = (int)menI.CommandParameter;
            var col = (ObservableCollection<ListViewDataSource>)listView.ItemsSource;
            int actualIndex = FindMahIndex(key, col);

            col.RemoveAt(actualIndex);
        }

        void Handle_Clicking_More_Button(object sender, System.EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var url = (string)menuItem.CommandParameter;
			Device.OpenUri(new System.Uri(url));            
        }
    }
}
