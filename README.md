# Website Generator API

### How to test API

#### Create new Website Blocks
```
POST https://localhost:7220/api/v1/WebsiteBlocks?key={{KEY}}
[
    {
        "Id": "HeaderBlock",
        "BlockOrder": 0,
        "BusinessName": "My Business",
        "LogoVisible": true,
        "NavigationMenu": {
            "MenuItems": [
                {
                    "Text": "About us",
                    "Link":"/about"
                }
            ]
        },
        "Button": {
            "Text":  "555-555-5555",
            "Display": true,
            "Icon": "phone",
            "Event": "onClick"
        }
    },
    {
        "Id": "HeroBlock",
        "BlockOrder": 1,
        "HeadlineText": "Welcome to our website",
        "DescriptionText": "Explore our services",
        "Button": {
            "Text":  "Get In Touch",
            "Display": true,
            "Icon": "none",
            "Event": "onClick"
        },
        "HeroImage": "banner.png",
        "ImageAlignment": "right",
        "ContentAlignment": "center"
    },
    {
        "Id": "ServicesBlock",
        "BlockOrder": 2,
        "HeadlineText": "Our Services",
        "ServiceCards": [
            {
                "ServiceName": "Logo Design",
                "ServiceDescription": "Lorem ipsum",
                "ServiceImage": "desk.jpg",
                "Button": {
                    "Text":  "Learn More",
                    "Display": true,
                    "Icon": "none",
                    "Event": "onClick"
                }
            }
        ]
    }
]

```

#### Get Website Blocks by key
```
GET https://localhost:7220/api/v1/WebsiteBlocks/{{KEY}}
```

#### Update a section
```
PUT https://localhost:7220/api/v1/WebsiteBlocks/{{KEY}}/sections/{{SECTION_ID}}
```

#### Remove a section
```
DELETE https://localhost:7220/api/v1/WebsiteBlocks/{{KEY}}/sections/{{SECTION_ID}}
```
