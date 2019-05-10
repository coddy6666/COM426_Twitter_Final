using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Assignment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Tweet> tweets;
       

        public MainWindow()
        {

            InitializeComponent();




            /* Username info at top to welcome user! */
            using (StreamReader r = new StreamReader("User.json"))

            {

                string json = r.ReadToEnd();

                User user = JsonConvert.DeserializeObject<User>(json, new IsoDateTimeConverter { DateTimeFormat = "ddd MMM dd HH:mm:ss zz00 yyyy" });



                UserName.Text = (user.screen_name);
                Amount.Text = $"{user.followers_count}";

                Console.WriteLine(user.created_at);

            }

            /* Followers info relevant to the user! */
            using (StreamReader r = new StreamReader("Followers.json"))

            {

                string json = r.ReadToEnd();

                List<User> users = JsonConvert.DeserializeObject<List<User>>(json, new IsoDateTimeConverter { DateTimeFormat = "ddd MMM dd HH:mm:ss zz00 yyyy" });






                /*  my attempt at showing all the users, using an ++ loop, until there is no more! for showing followers */

                System.Collections.IList list = users;

                foreach (User user in users)
                {
                    FollowerBox.Items.Add(user.name);

                }




            }


            /* FOR MY TWEETS SECTION */

            using (StreamReader r = new StreamReader("Tweets.json"))
            {
                string json = r.ReadToEnd();
                tweets = JsonConvert.DeserializeObject<List<Tweet>>(json, new IsoDateTimeConverter { DateTimeFormat = "ddd MMM dd HH:mm:ss zz00 yyyy" });
            }

        }



        private void FollowerBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /* FOR MY TWEETS SECTION! ONCE THE USER HAS clicked the button to show latest tweets */


            using (StreamReader r = new StreamReader("Tweets.json"))

            {

                string json = r.ReadToEnd();

                List<Tweet> tweets = JsonConvert.DeserializeObject<List<Tweet>>(json, new IsoDateTimeConverter { DateTimeFormat = "ddd MMM dd HH:mm:ss zz00 yyyy" });







                /* a for loop to show all the tweets until there is no more! */

                System.Collections.IList list = tweets;
                for (int a = 0; a < list.Count; a++)
                {
                    foreach (Tweet text in tweets)
                    {
                        Tweets.Items.Add(tweets[a].text);

                    }
                }

            }

        }

    

        private void FetchTweets_Click(object sender, RoutedEventArgs e)
        {

            using (StreamReader r = new StreamReader("Tweets.json"))

            {

                string json = r.ReadToEnd();

                List<Tweet> tweets = JsonConvert.DeserializeObject<List<Tweet>>(json, new IsoDateTimeConverter { DateTimeFormat = "ddd MMM dd HH:mm:ss zz00 yyyy" });
                
                /* a for loop to show all the tweets until there is no more! */

                    System.Collections.IList list = tweets;
                for (int a = 0; a < list.Count; a++)
                {
                    foreach (Tweet text in tweets)
                    {
                        Tweets.Items.Add(tweets[a].text);

                    }
                }

            }
        }

        // Below is Button to upload latest tweet to tweets section

        private void TweetButton_Click(object sender, RoutedEventArgs e)
        {
            Tweet t = new Tweet();
            t.text = textbox.Text;
            tweets.Insert(0, t);
            Tweets.Items.Insert(0, t.text);
        }

       
    }
}
