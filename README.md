Employee Attendance System

Technologies:
C#
MSSQL Server
EntityFramework Core

baseUrl=https://localhost:5001

LOGIN=https://localhost:5001/Auth/Logins

Required field:
        userName:
        password:
        
GETALL EMPLOYEE :
            https://localhost:5001/Employee/GetAllEmployee

GET SINGLE EMPLOYEE:
            https://localhost:5001/Employee/Get/
            
required url paramter
            id:
            
SAVE EMPLOYEE DETAIL:
            https://localhost:5001/Employee/save
            
required field:
    
    firstName:string; 
    lastName:string;
    gender:string;
    dob:string;
    
    
optional field:
    middleName:string;
    address:string;
    contact:string;
    isActive:boolean;
    
UPDATE EMPLOYEE DETAIL:
    https://localhost:5001/Employee/updateEmployee
    
ADD EMPLOYEE ATTENDANCE:
        https://localhost:5001/Employee/saveAttendance
        
TOGGLE EMPLOYEE STATUS:
        https://localhost:5001//Employee/saveAttendance
    
        
