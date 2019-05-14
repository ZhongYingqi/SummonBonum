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
                if (context.Provinces.Any())
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
            },
            new Province() {
                Name="Beijing",
            },
            new Province() {
                Name="Shanghai",
            },
            new Province() {
                Name="Tibet",
            },
            new Province() {
                Name="Nanjing",
            },
            new Province() {
                Name="Hainan",
            },
            new Province() {
                Name="Sicuan",
            },
        };

            return provinces;
        }

        public static List<City> GetCities(ApplicationDbContext context)
        {
            List<City> cities = new List<City>() {
            new City {
                CityName="Dongguan",
                ProvinceId=context.Provinces.FirstOrDefault(c => c.Name=="Guangdong").ProvinceId
            },
            new City {
                CityName="Beijing",
                ProvinceId=context.Provinces.FirstOrDefault(c => c.Name=="Beijing").ProvinceId
            },
            new City {
                CityName="Shanghai",
                ProvinceId=context.Provinces.FirstOrDefault(c => c.Name=="Shanghai").ProvinceId
            },
            new City {
                CityName="Shangri-la",
                ProvinceId=context.Provinces.FirstOrDefault(c => c.Name=="Tibet").ProvinceId
            },
            new City {
                CityName="Jiangsu",
                ProvinceId=context.Provinces.FirstOrDefault(c => c.Name=="Nanjing").ProvinceId
            },
            new City {
                CityName="Haikou",
                ProvinceId=context.Provinces.FirstOrDefault(c => c.Name=="Hainan").ProvinceId
            },
            new City {
                CityName="Chengdu",
                ProvinceId=context.Provinces.FirstOrDefault(c => c.Name=="Sicuan").ProvinceId
            },
        };

            return cities;
        }
    }
}
