# TextNumberConverterAPI
![GitHub issues](https://img.shields.io/github/issues/cansozbir/TextNumberConverterAPI) ![GitHub contributors](https://img.shields.io/github/contributors/cansozbir/TextNumberConverterAPI)  ![GitHub forks](https://img.shields.io/github/forks/cansozbir/TextNumberConverterAPI) ![GitHub Repo stars](https://img.shields.io/github/stars/cansozbir/TextNumberConverterAPI?color=yellow) ![GitHub](https://img.shields.io/github/license/cansozbir/TextNumberConverterAPI)


The TextNumberConverterAPI is a RESTful API that allows users to convert text containing numbers into their corresponding numeric representation. The API supports the conversion of Turkish numbers and provides a flexible architecture to support additional languages in the future.


## Installation and Setup
To run the TextNumberConverterAPI on your machine, make sure you have the following prerequisites installed:
- .NET 7 SDK
- Docker (Optional)

Clone the repository to your local machine:

```
git clone https://github.com/your-username/TextNumberConverterAPI.git
```

Navigate to the project directory:
```
cd TextNumberConverterAPI
dotnet run --project=TextNumberConverterAPI --urls="http://localhost:5000"
```
\
Alternatively, if you have docker running on background, you can run the project by command below, this way you don't need to install any .NET SDK on your machine.
```
docker-compose up
```

The API will be accessible at http://localhost:5000.

You can also use Swagger to test the API http://localhost:5000/swagger/index.html


## API Endpoints
The TextNumberConverterAPI provides a single endpoint for converting text numbers:

`POST /api/TextNumberConverter`

Converts text containing numbers to their numeric representation. The request body should be a JSON object with the following structure:

Sample Request: <br>
POST /api/TextNumberConverter
```
{
    "userText": "Elli altı bin lira kredi alıp üç yılda geri ödeyeceğim."
}
```

The API will respond with a JSON object that replaces numeric representations:
```
{
    "output": "56000 lira kredi alıp 3 yılda geri ödeyeceğim."
}
```

## Supported Languages
The current version of the TextNumberConverterAPI supports the conversion of Turkish numbers. The Turkish language has specific rules for numbers, and the API uses appropriate strategies and regular expressions to handle Turkish numbers accurately.

Extending Language Support
The TextNumberConverterAPI is designed to be easily extendable to support additional languages. To add support for a new language, follow these steps:

Create a new implementation of the ITextNumberReplaceStrategy interface for the target language. Implement the ReplaceAll method to handle the replacement of text numbers with their numeric representation based on the language-specific rules.

Add the language-specific regular expressions and helper method interfaces and its implementations. This step is specific to the target language.

Create a new implementation of the ITextToNumberConverter interface that takes the appropriate regex helper for the target language. Implement the ConvertToNumber method to handle the conversion of text numbers to numeric representation.

Finally, add the necessary configurations in the ITextNumberReplaceStrategyFactory and TextNumberReplaceStrategyFactory to select the appropriate strategy based on the language specified.

## Testing
The TextNumberConverterAPI includes a comprehensive test suite to ensure the accuracy and robustness of the conversion logic. To run the tests, use the following command:
```
dotnet test
```
The tests are implemented using the Moq and the xUnit testing framework and cover various scenarios for text number conversion, edge cases, and language-specific rules.


## TODOs
- [ ] Make sure the project is passing all of the unit tests.
- [ ] Currently, it does not support compound inputs such as "beş100elli", add a support for that.

## Contributing
Contributions to the TextNumberConverterAPI project are welcome. To contribute, follow these steps:

- Fork the repository and create a new branch for your feature or bug fix.

- Make your changes and ensure the code passes all tests and follows coding guidelines.

- Submit a pull request with a clear description of the changes and their purpose.

# License
The TextNumberConverterAPI is open-source software licensed under the MIT License. Feel free to use, modify, and distribute the code according to the terms of the license.

# Contact
For any questions or feedback, please reach out to the project maintainers at cansozbirdev@gmail.com