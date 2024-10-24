# CMCSProjectPART2
link:  [MendessitholeST10332172-MENDES-SITHOLE-PROGRAM-6212-2B-PART-2][https://github.com/Mendessithole2002/Part-2]


Open the Project in Visual Studio:

Open Visual Studio.
Go to File > Open > Project/Solution.
Navigate to the project folder and open the .sln file.


Run the Application:

Press F5 or click on the IIS Express button to start the application.
The application should launch in your default web browser.
Running the Application
Once the application is running, you can perform the following actions:

Fill in Lecturer Details:

Enter the lecturer's name, surname, employee number, and contact details.
Enter Claim Details:

Input the module, program, number of hours worked, and the hourly rate.
Add Multiple Modules:

If the lecturer has worked on multiple modules, you can click "Add Another Module" to include more details.
Submit the Claim:

After filling in the details, click on the "Submit Claim" button.
Issues Encountered
1. Error: type does not contain a definition for name
Problem: This error occurred due to an incorrect reference to a model property. For example, I mistakenly referred to a property named name in a model that did not contain such a property.
Solution: The issue was resolved by correctly referring to the properties in the model that actually existed, such as LecturerName, LecturerSurname, Programme, etc.
2. Misalignment between UI and Backend Code
Problem: Initially, the UI design in the Razor view did not match the backend model, causing errors when submitting the form.
Solution: I updated the Razor view to correctly bind the form fields to the model properties and adjusted the model to include all necessary properties.
3. Form Submission Issues
Problem: The form was not submitting correctly due to missing or incorrect form field names and model binding issues.
Solution: I ensured that all form fields were properly named and bound to the correct model properties. Additionally, I added necessary validations to prevent submission of incomplete forms.
