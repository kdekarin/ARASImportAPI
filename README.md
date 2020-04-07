# ARASImportAPI
API for importing ARAS packages


HOW TO import package using ConsoleUpgrade tool or REST API:
________________________________________________________________
INSTALL PACKAGE IMPORT EXPORT UTILITIES (CONSOLE UPGRADE TOOL) -> You shall contant ARAS support for it
1. Create PackageImportExportUtilities tool at following location:
	C:\Program Files (x86)\PackageImportExportUtilities

2. You shall contain following file structure now on your DISC:
	C:\Program Files (x86)\PackageImportExportUtilities\ConsoleUpgrade
	C:\Program Files (x86)\PackageImportExportUtilities\ConsoleUpgrade\ConsoleUpgrade
	C:\Program Files (x86)\PackageImportExportUtilities\ConsoleUpgrade\IOM.dll
	C:\Program Files (x86)\PackageImportExportUtilities\ConsoleUpgrade\Libs.dll

________________________________________________________________
CREATE SOME ARAS IMPORT PACKAGE SO YOU CAN LATER IMPORT IT
3. Create folder "01_Package" (you can name it differently):
	C:\Program Files (x86)\PackageImportExportUtilities\ConsoleUpgrade\01_Package
	NOTE: You can create this folder on any location as well as PackageImportExportUtilities can be created on any location on your hard drive,
		  only thing that is important is that one level above your newly created folder shall be located following files: ConsoleUpgrade, IOM.dll, Libs.dll

4. Copy paste in folder "01_Package" ARAS package that you would like to import it:
	NOTE: now your folder structure contains ARAS import manfiest file and as well ARAS folder containing AML files
	C:\Program Files (x86)\PackageImportExportUtilities\ConsoleUpgrade\01_Package\MySamplePackage\...
	C:\Program Files (x86)\PackageImportExportUtilities\ConsoleUpgrade\01_Package\imports.mf

________________________________________________________________
IMPORT PACKAGE USING CONSOLE UPGRADE TOOL
5. Open CMD and navigate to your import package directory:
cd C:\Program Files (x86)\PackageImportExportUtilities\ConsoleUpgrade\01_Package

6. Import package using console upgrade tool:
..\ConsoleUpgrade.exe server="http://localhost/InnovatorServer" login="admin" database="InnovatorSolutions" password="************" release="rel7.2" import merge verbose description="My secription" mfFile="imports.mf" log="log/myLogFile.txt" dir="C:\Program Files (x86)\PackageImportExportUtilities\ConsoleUpgrade\01_Package\"
NOTE: Use following command to get more help about command parameters: "..\ConsoleUpgrade.exe" 
	  or read documentation in the ARAS official book: Aras Innovator 12, Package Import Export Utilities, chapter 3.4 Console Upgrade Tool (page 13)
	  or access documentation online: https://community.aras.com/f/development/3554/automated-deployment-to-production

7. Package is imported, you can find your log file on the location: C:\Program Files (x86)\PackageImportExportUtilities\ConsoleUpgrade\01_Package\log

________________________________________________________________
RUN API

5. Clone this project at: C:\TIS\ARASImportAPI

6. Install .NET Core Runtime and hosting bundle

7. Open CMD, navigate and execute:
cd C:\TIS\ARASImportAPI\CoreWebApi
dotnet build
dotnet run

8. Visit: http://localhost:5000

9. Create HTTP request:
	* Type:POST
	* URL: http://localhost:5000/api/CreateImport/
	* Content-Type: application/json
	* Body:
	{	
    "guid": "abc",
	"serverURL": "http://localhost/InnovatorServer",
	"login": "admin",
	"password": "************",
	"databaseName": "InnovatorSolutions",
	"description": "Some description",
	"release": "rel9.2",
	"manifestFileName": "imports.mf",
	"importDirectory": "C:/Program Files (x86)/PackageImportExportUtilities/ConsoleUpgrade/01_Package/",
	"shallMerge": true,
	"shallLogVerbose": true,
	"level": null,
	"shallImportInThorughMode": true
    }
