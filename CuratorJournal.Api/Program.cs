using CuratorJournal.DataAccess.Database;
using CuratorJournal.DataAccess.Repositories.Implementation;
using CuratorJournal.DataAccess.Repositories.Interfaces;
using CuratorJournal.DataAccess.Services.Implementation;
using CuratorJournal.DataAccess.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Database
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Curator Journal API",
        Version = "v1",
        Description = "API for Curator Journal System"
    });
});

builder.Services.AddScoped<IClassHourService, ClassHourService>();
builder.Services.AddScoped<IClassHourRepository, ClassHourRepository>();
builder.Services.AddScoped<ICuratorService, CuratorService>();
builder.Services.AddScoped<ICuratorRepository, CuratorRepository>();
builder.Services.AddScoped<ICuratorCharacteristicService, CuratorCharacteristicService>();
builder.Services.AddScoped<ICuratorCharacteristicRepository, CuratorCharacteristicRepository>();
builder.Services.AddScoped<IGroupPostService, GroupPostService>();
builder.Services.AddScoped<IGroupPostRepository, GroupPostRepository>();
builder.Services.AddScoped<IHobbyService, HobbyService>();
builder.Services.AddScoped<IHobbyRepository, HobbyRepository>();
builder.Services.AddScoped<IIndividualWorkService, IndividualWorkService>();
builder.Services.AddScoped<IIndividualWorkRepository, IndividualWorkRepository>();
builder.Services.AddScoped<IParentService, ParentService>();
builder.Services.AddScoped<IParentRepository, ParentRepository>();
builder.Services.AddScoped<IParentMeetingService, ParentMeetingService>();
builder.Services.AddScoped<IParentMeetingRepository, ParentMeetingRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IQualificationService, QualificationService>();
builder.Services.AddScoped<IQualificationRepository, QualificationRepository>();
builder.Services.AddScoped<ISocialStatusService, SocialStatusService>();
builder.Services.AddScoped<ISocialStatusRepository, SocialStatusRepository>();
builder.Services.AddScoped<ISpecificationService, SpecificationService>();
builder.Services.AddScoped<ISpecificationRepository, SpecificationRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentClassHourService, StudentClassHourService>();
builder.Services.AddScoped<IStudentClassHourRepository, StudentClassHourRepository>();
builder.Services.AddScoped<IStudentInDormitoryService, StudentInDormitoryService>();
builder.Services.AddScoped<IStudentInDormitoryRepository, StudentInDormitoryRepository>();
builder.Services.AddScoped<IStudyGroupService, StudyGroupService>();
builder.Services.AddScoped<IStudyGroupRepository, StudyGroupRepository>();
builder.Services.AddScoped<ITeacherCategoryService, TeacherCategoryService>();
builder.Services.AddScoped<ITeacherCategoryRepository, TeacherCategoryRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Swagger for all environments
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Curator Journal v1");
    c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();