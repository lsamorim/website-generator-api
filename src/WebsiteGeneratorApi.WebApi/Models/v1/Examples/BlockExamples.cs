using Domain.Components.Blocks;
using Domain.Components;

namespace WebsiteGeneratorApi.WebApi.Models.v1.Examples
{
    public class BlockExamples
    {
        public static HeaderBlock HeaderBlockExample = new HeaderBlock
        {
            BlockOrder = 0,
            BusinessName = "My Business",
            LogoVisible = true,
            NavigationMenu = new NavigationMenu()
            {
                MenuItems = new[]
        {
                    new MenuItem
                    {
                        Text = "About Us",
                        Link = "/about"
                    }
                }
            },
            Button = new CTAButton
            {
                Text = "555-555-5555",
                Display = true,
                Icon = "phone",
                Event = "onClick"
            }
        };

        public static HeroBlock HeroBlockExample = new HeroBlock
        {
            BlockOrder = 1,
            HeadlineText = "Welcome to our website",
            DescriptionText = "Explore our services",
            Button = new CTAButton
            {
                Text = "Get In Touch",
                Display = true,
                Icon = "none",
                Event = "onClick"
            },
            HeroImage = "banner.png",
            ImageAlignment = "right",
            ContentAlignment = "center"
        };

        public static ServicesBlock ServicesBlockExample = new ServicesBlock
        {
            BlockOrder = 2,
            HeadlineText = "Our Services",
            ServiceCards = new[]
                        {
                            new ServiceCard
                            {
                                ServiceName = "Logo Design",
                                ServiceDescription = "Lorem ipsum",
                                ServiceImage = "desk.jpg",
                                Button = new CTAButton
                                {
                                    Text =  "Learn More",
                                    Display = true,
                                    Icon = "none",
                                    Event = "onClick"
                                }
}
                        }
        };
    }
}
