using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SummonBonum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummonBonum.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                // Look for any Provinces.
                if (context.Provinces.Any() && context.Cities.Any())
                {
                    return;   // DB has already been seeded
                }

                var provinces = DummyData.GetProvinces().ToArray();
                context.Provinces.AddRange(provinces);
                context.SaveChanges();

                var cities = DummyData.GetCities(context).ToArray();
                context.Cities.AddRange(cities);
                context.SaveChanges();
            }
        }

        public static List<Province> GetProvinces()
        {
            List<Province> provinces = new List<Province>() {
            new Province() {
                Name="Guangdong",
                PictureUrl="https://tse1-mm.cn.bing.net/th?id=AMMS_7d65542099274c1d80441ff8679b2997&w=192&h=149&c=8&rs=1&o=5&dpr=1.5&pid=3.1&rm=2",
            },
            new Province() {
                Name="Beijing",
                PictureUrl="http://cache.house.sina.com.cn/citylifehouse/citylife/fe/1e/20090506_5674_1.jpg",
            },
            new Province() {
                Name="Shanghai",
                PictureUrl="http://y1.ifengimg.com/a/2016_10/73e37122ef1fde1.jpg",
            },
            new Province() {
                Name="Tibet",
                PictureUrl="http://img2.chinadaily.com.cn/images/201712/20/5a3a0eb1a31008cfb2e7dfb8.jpeg",
            },
            new Province() {
                Name="Nanjing",
                PictureUrl="http://www.jstour.com/Public/image_lib/2014/10/20/9679eb8a843cd9d7a2b843b46701ded3.jpg",
            },
            new Province() {
                Name="Hainan",
                PictureUrl="http://pic3.nipic.com/20090525/2708449_132304004_2.jpg",
            },
            new Province() {
                Name="Sichuan",
                PictureUrl="http://pic10.nipic.com/20101013/5943886_163005079186_2.jpg",
            },
        };

            return provinces;
        }

        public static List<City> GetCities(ApplicationDbContext context)
        {
            List<City> cities = new List<City>() {
            new City {
                CityName="Dongguan",
                PictureUrl="http://pic20.nipic.com/20120424/9920043_204918473183_2.jpg",
                ProvinceId=context.Provinces.FirstOrDefault(c => c.Name=="Guangdong").ProvinceId
            },
            new City {
                CityName="Beijing",
                PictureUrl="http://pic5.bbzhi.com/fengjingbizhi/meilideshoudubeijingfengguangbizhi/meilideshoudubeijingfengguangbizhi_460618_3.jpg",
                ProvinceId=context.Provinces.FirstOrDefault(c => c.Name=="Beijing").ProvinceId
            },
            new City {
                CityName="Shanghai",
                PictureUrl="http://pic.lvmama.com/uploads/pc/place2/2016-12-26/40a76c88-fbf6-4b3d-a4c1-eb49746e0a91.jpg",
                ProvinceId=context.Provinces.FirstOrDefault(c => c.Name=="Shanghai").ProvinceId
            },
            new City {
                CityName="Shangri-la",
                PictureUrl="https://a1.bbkz.net/forum/attachment.php?attachmentid=1560247&d=1437063759",
                ProvinceId=context.Provinces.FirstOrDefault(c => c.Name=="Tibet").ProvinceId
            },
            new City {
                CityName="Jiangsu",
                PictureUrl="http://www.diyifanwen.com/images/jiangsu/0872315112885421.jpg",
                ProvinceId=context.Provinces.FirstOrDefault(c => c.Name=="Nanjing").ProvinceId
            },
            new City {
                CityName="Haikou",
                PictureUrl="http://pic1.beibaotu.com/item_images/000/00/37/68/9025205_b.jpg",
                ProvinceId=context.Provinces.FirstOrDefault(c => c.Name=="Hainan").ProvinceId
            },
            new City {
                CityName="Chengdu",
                PictureUrl="https://www.ab-road.net/CSP/img/INF/SIGHT/36/001136/001136_x.jpg",
                ProvinceId=context.Provinces.FirstOrDefault(c => c.Name=="Sicuan").ProvinceId
            },
        };

            return cities;
        }
    }
}
