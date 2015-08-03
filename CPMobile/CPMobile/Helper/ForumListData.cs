using CPMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CPMobile.Helper
{
    public static class ForumListData
    {
        public static List<ForumType> GetData()
		{
            return new List<ForumType> {
				new ForumType () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1s07h2W") },
					title = ".Net Framework",
					ForumId=1650
				},
                new ForumType () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1s07h2W") },
					title = "C/C++/MFC",
					ForumId=1647
				},
                new ForumType () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1s07h2W") },
					title = "C#",
					ForumId=1649
				},
                new ForumType () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1s07h2W") },
					title = "Java",
					ForumId=1643
				},
                new ForumType () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1s07h2W") },
					title = "LINQ",
					ForumId=1004117
				},
                new ForumType () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1s07h2W") },
					title = "Visual Basic",
					ForumId=1646
				},
                new ForumType () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1s07h2W") },
					title = "Visual Studio",
					ForumId=3831
				},
                new ForumType () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1s07h2W") },
					title = "WCF and WF",
					ForumId=1004114
				},
                new ForumType () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1s07h2W") },
					title = ".NetFramework",
					ForumId=1650
				},
                new ForumType () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1s07h2W") },
					title = "Windows form",
					ForumId=387161
				},
                new ForumType () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1s07h2W") },
					title = "ASP.NET",
					ForumId=12076
				},
                new ForumType () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1s07h2W") },
					title = "JavaScript",
					ForumId=1580226
				},
                new ForumType () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1s07h2W") },
					title = "Web Development",
					ForumId=1640
				},
                new ForumType () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1s07h2W") },
					title = "Android",
					ForumId=1848626
				},
                new ForumType () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1s07h2W") },
					title = "iOS",
					ForumId=1876716
				},
                 new ForumType () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1s07h2W") },
					title = "Mobile",
					ForumId=13695
				},
                 new ForumType () {
					ImageSource = new UriImageSource { Uri = new Uri ("http://bit.ly/1s07h2W") },
					title = "Database",
					ForumId=1725
				},
            };
        }
    }
}
