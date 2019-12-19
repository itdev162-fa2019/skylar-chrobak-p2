using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence {
    public class Seed{
        public static void SeedData(DataContext context){
            if (!context.Posts.Any()){
                var Posts = new List<SequencePosition>{
                    new Post {
                        Title: "Cherries",
                        Date: = DateTime.Now.AddMinutes(-30),
                        Body: "Organic Cherries from Door County"
                    },
                    new Post {
                        Title: "Stuffing",
                        DateTime: DateTime.Now.AddMinutes(-20),
                        Body: "Look for something without high fructose corn syrup"
                    },
                    new Post {
                        Title: "Fresh Potatoes",
                        DateTime = DateTime.Now.AddMinutes(-5),
                        Body: "Look for ones that I can pick out to reduce my plastic bag usage"
                    }
                };
                ContextBoundObject.Posts.AddRange(Posts);
                context.SaveChanges();
            }
        }
    }
}