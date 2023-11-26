
using CourseApp.Controllers;
using Service.Enums;
using Service.Helpers.Extensions;
using Spectre.Console;

AccauntControllers accauntControllers = new AccauntControllers();


static void GetOp()
{
    ConsoleColor.Magenta.WriteConsole("Choose operation: (1)-Register ; (2)-Log In ");
}
static void GetMenu()

{
    ConsoleColor.DarkYellow.WriteConsole("Group Operation: (3)-Create; (4)-GetAll; (5)-Edit; (6)-Delete; (7)-GetById; (8)-Search ; (9)-Sort ---- Student Operation: (10)-Create ; (11)-GetAll; (12)-Edit; (13)-Delete; (14)-GetById; (15)-Search; (16)-Sort");

}


GroupController groupController = new GroupController();
StudentController studentController = new StudentController();

AnsiConsole.Write(new FigletText("Welcome CourseApp").Centered().Color(Color.DarkKhaki));


while (true)
{
Options: GetOp();

Option: string optionstr = Console.ReadLine();
    int option;
    bool isCorrectOption = int.TryParse(optionstr, out option);

    if (isCorrectOption)
    {
        switch (option)
        {
            case (int)AccauntOperationTypes.register:
                accauntControllers.Register();
                goto Options;
            case (int)AccauntOperationTypes.login:
                accauntControllers.LogIn();
                break;
            default:
                ConsoleColor.Red.WriteConsole("Operation is wrong,please try again:");
                goto Options;

        }
    }
    else
    {
        ConsoleColor.Red.WriteConsole("Operation format is wrong,please try again");
        goto Option;
    }

    AnsiConsole.Write(new FigletText("Menu").Centered().Color(Color.Blue1));
        


    Case: GetMenu();

    Operation: string opstr = Console.ReadLine();
    int operation;
    bool isCorrectOp = int.TryParse(opstr, out operation);

    if (isCorrectOp)
    {
        switch (operation)
        {
            case (int)GroupOperationTypes.GroupCreate:
                groupController.Create();
                goto Case;
            case (int)GroupOperationTypes.GroupGetAll:
                groupController.GetAll();
                goto Case;
            case (int)GroupOperationTypes.GroupEdit:
                groupController.Edit();
                goto Case;
            case (int)GroupOperationTypes.GroupDelete:
                groupController.Delete();
                goto Case;
            case (int)GroupOperationTypes.GroupGetById:
                groupController.GetById();
                goto Case;
            case (int)GroupOperationTypes.GroupSearch:
                groupController.SearchByName();
                goto Case;
            case (int)GroupOperationTypes.GroupSort:
                groupController.SortByCapacity();
                goto Case;
            case (int)StudentOperationType.StudentCreate:
                studentController.Create();
                goto Case;
            case (int)StudentOperationType.StudentGetAll:
                studentController.GetAll();
                goto Case;
            case (int)StudentOperationType.StudentEdit:
                studentController.StudentEdit();
                goto Case;
            case (int)StudentOperationType.StudentDelete:
                studentController.Delete();
                goto Case;
            case (int)StudentOperationType.StudentGetById:
                studentController.GetById();
                goto Case;
            case (int)StudentOperationType.StudentSearch:
                studentController.SearchFullName();
                goto Case;
            case (int)StudentOperationType.StudentSort:
                studentController.SortByAge();
                goto Case;

            default:
                ConsoleColor.Red.WriteConsole("Operation is wrong,please try again:");
                goto Operation;
        }

    }
    else
    {
        ConsoleColor.Red.WriteConsole("Operation format is wrong,please try again");
        goto Operation;
    }


}

