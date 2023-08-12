using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eduzest.HRMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    branchname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    mobilenumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    state = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    createdon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdby = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    updatedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "LogDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    message = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    stacktrace = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    targetsite = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdby = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    updatedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "SalaryTemplates",
                columns: table => new
                {
                    salarytemplateid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    salarygrade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    basicsalary = table.Column<float>(type: "real", nullable: true),
                    overtimerate = table.Column<float>(type: "real", nullable: true),
                    totalallowances = table.Column<float>(type: "real", nullable: true),
                    totaldeduction = table.Column<float>(type: "real", nullable: true),
                    netsalary = table.Column<float>(type: "real", nullable: true),
                    createdon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdby = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    updatedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryTemplates", x => x.salarytemplateid);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    deptid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createdon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdby = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    updatedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.deptid);
                    table.ForeignKey(
                        name: "FK_Departments_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId");
                });

            migrationBuilder.CreateTable(
                name: "Allowances",
                columns: table => new
                {
                    allowanceid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    allowancename = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ammount = table.Column<float>(type: "real", nullable: true),
                    salarytemplate = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalarytemplateNavigationSalarytemplateid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createdon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdby = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    updatedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allowances", x => x.allowanceid);
                    table.ForeignKey(
                        name: "FK_Allowances_SalaryTemplates_SalarytemplateNavigationSalarytemplateid",
                        column: x => x.SalarytemplateNavigationSalarytemplateid,
                        principalTable: "SalaryTemplates",
                        principalColumn: "salarytemplateid");
                });

            migrationBuilder.CreateTable(
                name: "Deductions",
                columns: table => new
                {
                    deductionid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    deductionname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ammount = table.Column<float>(type: "real", nullable: true),
                    salarytemplateid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createdon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdby = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    updatedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deductions", x => x.deductionid);
                    table.ForeignKey(
                        name: "FK_Deductions_SalaryTemplates_salarytemplateid",
                        column: x => x.salarytemplateid,
                        principalTable: "SalaryTemplates",
                        principalColumn: "salarytemplateid");
                });

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    Desigid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Designationname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createdon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdby = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    updatedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.Desigid);
                    table.ForeignKey(
                        name: "FK_Designations_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK_Designations_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "deptid");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDetails",
                columns: table => new
                {
                    employeecode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    branchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    departmentdeptid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    desigid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    qualification = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    expdetails = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Totalexp = table.Column<int>(type: "int", nullable: true),
                    Dateofjoin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    employeename = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fathername = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    religion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    bloodgroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    dateofbirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    presentaddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    permanentaddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    profilepicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    facebook = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    twitter = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    linkedin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    bankname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    bankaddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ifsccode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    skipbankdetails = table.Column<bool>(type: "bit", nullable: true),
                    createdon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdby = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    updatedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDetails", x => x.employeecode);
                    table.ForeignKey(
                        name: "FK_EmployeeDetails_Branches_branchId",
                        column: x => x.branchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK_EmployeeDetails_Departments_departmentdeptid",
                        column: x => x.departmentdeptid,
                        principalTable: "Departments",
                        principalColumn: "deptid");
                    table.ForeignKey(
                        name: "FK_EmployeeDetails_Designations_desigid",
                        column: x => x.desigid,
                        principalTable: "Designations",
                        principalColumn: "Desigid");
                });

            migrationBuilder.CreateTable(
                name: "ExperienceDetails",
                columns: table => new
                {
                    experienceid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    employeeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fromdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    todate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    authorizedby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmpCodeEmployeeCodeNavigationEmployeecode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    createdon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdby = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    updatedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceDetails", x => x.experienceid);
                    table.ForeignKey(
                        name: "FK_ExperienceDetails_EmployeeDetails_EmpCodeEmployeeCodeNavigationEmployeecode",
                        column: x => x.EmpCodeEmployeeCodeNavigationEmployeecode,
                        principalTable: "EmployeeDetails",
                        principalColumn: "employeecode");
                });

            migrationBuilder.CreateTable(
                name: "RelievingDetails",
                columns: table => new
                {
                    relievingid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    fromdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    todate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dateofrelease = table.Column<DateTime>(type: "datetime2", nullable: true),
                    authorizedby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmpCodeEmployeeCodeNavigationEmployeecode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    createdon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdby = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    updatedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelievingDetails", x => x.relievingid);
                    table.ForeignKey(
                        name: "FK_RelievingDetails_EmployeeDetails_EmpCodeEmployeeCodeNavigationEmployeecode",
                        column: x => x.EmpCodeEmployeeCodeNavigationEmployeecode,
                        principalTable: "EmployeeDetails",
                        principalColumn: "employeecode");
                });

            migrationBuilder.CreateTable(
                name: "SalaryAssignments",
                columns: table => new
                {
                    assignid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    employeecode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    totalallowance = table.Column<float>(type: "real", nullable: true),
                    totaldeduction = table.Column<float>(type: "real", nullable: true),
                    overtimetotalhour = table.Column<int>(type: "int", nullable: true),
                    overtimeamount = table.Column<float>(type: "real", nullable: true),
                    netsalary = table.Column<float>(type: "real", nullable: true),
                    payvia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    accountnumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    remark = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmployeecodeNavigationEmployeecode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    createdon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdby = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    updatedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryAssignments", x => x.assignid);
                    table.ForeignKey(
                        name: "FK_SalaryAssignments_EmployeeDetails_EmployeecodeNavigationEmployeecode",
                        column: x => x.EmployeecodeNavigationEmployeecode,
                        principalTable: "EmployeeDetails",
                        principalColumn: "employeecode");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allowances_SalarytemplateNavigationSalarytemplateid",
                table: "Allowances",
                column: "SalarytemplateNavigationSalarytemplateid");

            migrationBuilder.CreateIndex(
                name: "IX_Deductions_salarytemplateid",
                table: "Deductions",
                column: "salarytemplateid");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BranchId",
                table: "Departments",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_BranchId",
                table: "Designations",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_DepartmentId",
                table: "Designations",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetails_branchId",
                table: "EmployeeDetails",
                column: "branchId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetails_departmentdeptid",
                table: "EmployeeDetails",
                column: "departmentdeptid");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetails_desigid",
                table: "EmployeeDetails",
                column: "desigid");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceDetails_EmpCodeEmployeeCodeNavigationEmployeecode",
                table: "ExperienceDetails",
                column: "EmpCodeEmployeeCodeNavigationEmployeecode");

            migrationBuilder.CreateIndex(
                name: "IX_RelievingDetails_EmpCodeEmployeeCodeNavigationEmployeecode",
                table: "RelievingDetails",
                column: "EmpCodeEmployeeCodeNavigationEmployeecode");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryAssignments_EmployeecodeNavigationEmployeecode",
                table: "SalaryAssignments",
                column: "EmployeecodeNavigationEmployeecode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allowances");

            migrationBuilder.DropTable(
                name: "Deductions");

            migrationBuilder.DropTable(
                name: "ExperienceDetails");

            migrationBuilder.DropTable(
                name: "LogDetails");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "RelievingDetails");

            migrationBuilder.DropTable(
                name: "SalaryAssignments");

            migrationBuilder.DropTable(
                name: "SalaryTemplates");

            migrationBuilder.DropTable(
                name: "EmployeeDetails");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
