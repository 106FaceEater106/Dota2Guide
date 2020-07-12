using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Dota2Guide
{
    public class SampleSkill
    {
        String title;
        String description;
        String imageSource;

        public String Title 
        {
            set 
            {
                title = value;
            }

            get 
            {
                return title;
            }
        }

        public String Description 
        {
            set 
            {
                description = value;
            }

            get 
            {
                return description;
            }
        }

        public String ImageSource 
        {
            set 
            {
                imageSource = value;
            }

            get 
            {
                return imageSource;
            }
        }

        public SampleSkill(String Title,String Description,String ImageSource) 
        {
            this.Title = Title;
            this.Description = Description;
            this.ImageSource = ImageSource;
        }
    }
}
