regarding the validation methods for the interface that I created insuring the integrity and accuracy of data entered into the slim gym database, I made sure that memberID is primary key so when entering duplicate key the user will receive error,

<img width="940" height="626" alt="image" src="https://github.com/user-attachments/assets/54da5126-a018-4492-b53c-7105c3058d9b" />

Also, when entering empty fields in first and last name text boxes, it will give a warning to the user to enter the names to make sure it’s not null,

<img width="940" height="534" alt="image" src="https://github.com/user-attachments/assets/daddc4b4-31da-4387-9a68-ff2d997b7183" />

The user cannot enter a duplicate email it should be unique,

<img width="940" height="626" alt="image" src="https://github.com/user-attachments/assets/d2857db0-070c-43db-bcdb-74616a993422" />

If no nationality entered it will be “Jordanian” by default, 

<img width="940" height="624" alt="image" src="https://github.com/user-attachments/assets/e23100ca-e7f7-4001-b96f-c6dcd5f9d12c" />

and the membership type will be monthly or yearly, and the user will have to choose between them in the combo box.
also I ensured the weight is greater than 30 and less than 250 , I implemented these codes for validation mechanism it will help me later in testing:

<img width="940" height="293" alt="image" src="https://github.com/user-attachments/assets/07564056-772e-47ef-82b7-fe5b1b3c43cb" />

phone number must be not null, also when entered correctly, it will be added to a separate table according to memberID, here is an example:

<img width="940" height="626" alt="image" src="https://github.com/user-attachments/assets/0da7a6ce-c8f3-467d-b4e7-32b4f846dc80" />

<img width="940" height="483" alt="image" src="https://github.com/user-attachments/assets/a99b6a84-bd7c-48ba-a5bb-9ed11316d235" />

