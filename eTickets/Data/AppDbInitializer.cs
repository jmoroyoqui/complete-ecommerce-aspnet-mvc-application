using eTickets.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                #region Insert data
                //Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                            {
                                new Cinema()
                                {
                                    Name = "Cinepolis",
                                    Logo = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fcinepolis.com%2F&psig=AOvVaw10G2xj1PxSLygES_klLAQ4&ust=1728056042491000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCMjMjsnE8ogDFQAAAAAdAAAAABAE",
                                    Description = "Cinepolis, la capital del cine."
                                },
                                new Cinema()
                                {
                                    Name = "Cinemex",
                                    Logo = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.pngegg.com%2Fes%2Fsearch%3Fq%3Dcinemex&psig=AOvVaw2IKM99fm3ZCPESFRHn70hY&ust=1728056188568000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCICUqo7F8ogDFQAAAAAdAAAAABAE",
                                    Description = "La magia del cine"
                                },
                                new Cinema()
                                {
                                    Name = "Cinemagic",
                                    Logo = "https://www.google.com/url?sa=i&url=https%3A%2F%2Flogos.fandom.com%2Fes%2Fwiki%2FCinemagic_%2528M%25C3%25A9xico%2529&psig=AOvVaw1g3YEhiXcQ0GA44nweJgAO&ust=1728056374304000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCKD21ufF8ogDFQAAAAAdAAAAABAE",
                                    Description = "Tu fabrica de sueños"
                                }
                            }
                        );
                    context.SaveChanges();
                }
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Nicolas Cage",
                            Bio = @"Nicolas Kim Coppola, ​​​​ conocido profesionalmente como Nicolas Cage, es un actor, actor de voz y productor de cine estadounidense.​ ​Ha recibido varios galardones, entre ellos un Premio de la Academia, un Premio del Screen Actors Guild y un Premio Globo de Oro.",
                            ProfilePictureURL = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.imdb.com%2Fname%2Fnm0000115%2F&psig=AOvVaw184OUAhBGb9_nUmBz-Ne9V&ust=1728056915357000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCODO05TJ8ogDFQAAAAAdAAAAABAE"
                        },
                        new Actor()
                        {
                            FullName = "Diane Kruger",
                            Bio = "Diane Kruger es una modelo y actriz de cine y televisión alemana. Es conocida por sus actuaciones en películas como Troya, Wicker Park, Feliz Navidad, La búsqueda, Mr. Nobody, Inglourious Basterds, entre otras.",
                            ProfilePictureURL = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.vogue.es%2Fmoda%2Fmodapedia%2Fpersonajes%2Fdiane-kruger%2F430&psig=AOvVaw1GfLvfSQT8yziqhyqnjr1z&ust=1728057614773000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCKiRx7XK8ogDFQAAAAAdAAAAABAE"
                        },
                        new Actor()
                        {
                            FullName = "Justin Bartha",
                            Bio = "Justin Lee Bartha es un actor estadounidense. Es conocido por su papel de Riley Poole en la película National Treasure o por interpretar a Doug Billings en The Hangover.",
                            ProfilePictureURL = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fnationaltreasure.fandom.com%2Fwiki%2FJustin_Bartha&psig=AOvVaw09TOmbUFTnl1t-YWqQVnfh&ust=1728057720410000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCKjTiezK8ogDFQAAAAAdAAAAABAE"
                        }
                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Jon Turteltaub",
                            Bio = "Jonathan Charles Turteltaub es un director, productor y guionista estadounidense, que ha trabajado tanto en cine como en televisión. Ha dirigido películas como Mientras dormías, Phenomenon o las dos entregas de National Treasure.",
                            ProfilePictureURL = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.sensacine.com%2Factores%2Factor-15988%2F&psig=AOvVaw3-lj2A9ouRCUmnDheZPW1b&ust=1728057872234000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCKjJz7fL8ogDFQAAAAAdAAAAABAE"
                        }
                    });
                    context.SaveChanges();
                }
                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "La Leyenda del Tesoro Perdido",
                            Description = "Un aventurero debe robar la Declaración de Independencia y usar su mapa escondido para encontrar una legendaria fortuna.",
                            Price = 35.6,
                            ImageURL = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fm.filmaffinity.com%2Fmx%2Fmovieuserreviews.php%3Fmovie_id%3D721724%26orderby%3D6%26page%3D3&psig=AOvVaw3oKsANV8KCp5-wkz8Rve9r&ust=1728058031837000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCOjb5frL8ogDFQAAAAAdAAAAABAQ",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = Enums.MovieCategory.Action
                        }
                    });
                    context.SaveChanges();
                }
                //Actors_Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        }
                    });
                    context.SaveChanges();
                }
                #endregion
            }
        }
    }
}
