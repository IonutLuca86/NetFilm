

using NetFilm.Database.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(policy => {
    policy.AddPolicy("CorsAllAccessPolicy", opt =>
    opt.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});

builder.Services.AddDbContext<NetFilmDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NetFilmConnection")));

ConfigureAutoMapper(builder.Services);
builder.Services.AddScoped<IDbService,DbService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsAllAccessPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();


void ConfigureAutoMapper(IServiceCollection services)
{
    var config = new MapperConfiguration(cfg =>
    {
        
        cfg.CreateMap<Director, DirectorDTO>()
        .ReverseMap();

        cfg.CreateMap<Genre, GenreDTO>().ReverseMap();
        cfg.CreateMap<Genre, GenreBaseDTO>().ReverseMap();
       
      
        cfg.CreateMap<Film, FilmDTO>().ReverseMap()
        .ForMember(dest => dest.Director, src => src.Ignore());
        cfg.CreateMap<FilmUpdateDTO, Film>()
        .ForMember(dest => dest.Director, src => src.Ignore())
        .ForMember(dest => dest.FilmGenres, src => src.Ignore())
        .ForMember(dest => dest.SimilarFilms, src => src.Ignore());
        cfg.CreateMap<FilmCreateDTO, Film>()
        .ForMember(dest => dest.Director, src => src.Ignore())
        .ForMember(dest => dest.FilmGenres, src => src.Ignore())
        .ForMember(dest => dest.SimilarFilms, src => src.Ignore());
       
        cfg.CreateMap<FilmGenre, FilmGenreDTO>().ReverseMap();
    
        cfg.CreateMap<SimilarFilm, SimilarFilmDTO>()
        .ReverseMap()
        .ForMember(dest => dest.Film, src => src.Ignore());
    });
    var mapper = config.CreateMapper();
    services.AddSingleton(mapper);
}
