using QuizAPI;
using QuizAPI.Adapters;
using QuizAPI.Persistance;
using QuizAPI.Repositories;
using QuizAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IQuizDatabaseContext, QuizDatabaseContext>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<QuestionAdapter, QuestionAdapter>(); // Maybe skip
builder.Services.AddScoped<QuestionService, QuestionService>(); // Maybe skip

builder.Services.AddScoped<IQuizAdapter, QuizAdapter>();
builder.Services.AddScoped<IQuizService, QuizService>();

builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<AnswerAdapter, AnswerAdapter>(); // Maybe skip
builder.Services.AddScoped<AnswerService, AnswerService>(); // Maybe skip
builder.Services.AddScoped<TriviaAdapter, TriviaAdapter>();



builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {

            //you can configure your custom policy
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();