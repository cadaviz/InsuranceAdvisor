# Insurance Advisor
## Summary

This application offers its users an insurance package personalized to their specific needs without requiring the user to understand anything about insurance, acting as their de facto insurance advisor.

Asking personal and risk-related questions and gathering some information about the user's vehicle and house allows this program to determine the user's insurance needs. Using this data to assess your risk profile for each line of insurance and then suggests an insurance plan ("economic", "regular", "responsible") corresponding to your risk profile.

## Features

- This application has a post webapi post endpoint, that receive a json payload as  [input](#Input).
- The insurance plan will be assessed and returned as json in [output](#Output).
- This application has a swagger that can be accessed [here](https://localhost:8080/swagger/index.html), once started.

### Input
The input `json` contains the following fields:

| Nome | Meaning | Value |
| ------ | ------ | ------ |
| age | User age | an integer equal or greater than 0 |
| dependents | The number of dependents of the user | an integer equal or greater than 0 |
| house | Contains information about users house | a nullable object |
| house.ownership_status | Users house ownership status | enum ("owned" or "mortgaged") |
| income | User income | a numeric equal or greater than 0 |
| marital_status | User marital status | enum ("single" or "married") |
| risk_questions | Answer 3 binary risk questions | bit (0 or 1) |
| vehicle | Contains information about users vehicle  | a nullable object  |
| vehicle.year | Year of vehicle manufacture | a positive integer |

Like this example:
```json
{
  "age": 35,
  "dependents": 2,
  "house": {"ownership_status": "owned"},
  "income": 0,
  "marital_status": "married",
  "risk_questions": [0, 1, 0],
  "vehicle": {"year": 2018}
}
```

### Output
The application will return the following JSON payload:

| Nome | Meaning | Value |
| ------ | ------ | ------ |
| auto | The insurance plan for vehicle | enum ("ineligible", "economic", "regular", "responsible") |
| disability | The insurance plan for disability | enum ("ineligible", "economic", "regular", "responsible") |
| home |  The insurance plan for home | enum ("ineligible", "economic", "regular", "responsible") |
| life | The insurance plan for life | enum ("ineligible", "economic", "regular", "responsible") |

Like this example:
```json
{
    "auto": "regular",
    "disability": "ineligible",
    "home": "economic",
    "life": "regular"
}
```

## How it runs?
**Insurance Advisor** was developed in .Net 6.0 and can run into Docker containers.

To build a Docker image, open the project root folder (the one that has the `Dockerfile` file) and run the following command in the terminal:

```sh
docker build -t insurance-advisor .
```

This way you will create an image of **Insurance Advisor** and get all necessary dependencies.

To run the application, run the following command in the terminal, in the same folder as the previous command:
```sh
docker run -d -p 8080:80 insurance-advisor
```

The application will respond in `http://localhost:8080/Insurance`.

## Development

This section will explain the approaches used in this application.

### Frameworks e Libraries
#### .Net 6
I used the most updated version of the .Net framework to be able to use some improvements available in the version.

### JSON Serializer
The most famous .Net serializer is NewtonSoft. Its fame and reliability is such that it was used, until a few versions ago, in Microsoft's project templates.
However, in the most current versions, a serializer was developed by Microsoft with the help of the creator of NewtonSoft. I chose to use this one to show that it is mature enough to meet the needs and to avoid using third-party libraries.

### Unit Tests
The project is covered by unit tests built with MSTest library. Following an idea used in choosing the serializer, I chose to use a native test library to show how it can be useful and efficient.

### Integration Tests
Integration tests were implemented using XUnit, it's a free, open source, community-focused testing tool for the . NET Framework.

### Fluent Validation
I used Fluent Validation to validate the limits and the mandatory nature of the request fields. I chose this library because it is simple and has super readable and intuitive rules and validations.

### Data Modeling
#### Score Calculation Engine
To develop the score calculation engine I used a mix of two patterns: Chain of Responsibility and Decorator.

Using Decorator increases code readability and gives visibility to different rules. Furthermore, it fits to SOLID principles, as classes have a unique responsibility, are open to extension and comply with Liskov's substitution principle.

The Chain of Responsibility organizes the assess of rules, facilitating the extension and understanding of the context.

### IoC
This application is basically divided into two projects, Api and Domain. The first is concerned with establish a channel for receiving and sendig data and consume domain services.

The Domain keeps most of its classes and entities for internal use, not being visible to other projects. The objective here is protect the domain and its entities, leaving public access only to elements that really should be public.

In this way, the inversion of control and dependency injection takes place in a slightly different way. A project called IoC was created to perform this control. He only knows the other projects that participate in the application. So each project takes care of its own dependency injection, while the IoC takes care of orchestrating that injection.

### DDD
Domain Driven Design was used with the objective of creating rich domains that represent entities and situations in the real world. These domains concentrate their rules and manage themselves, facilitating the relationship between entities and the implementation of new functionalities or the extension of existing ones.

Thus, request and response objects were created to carry data out of the Domain project, but all processing occurs on domain classes.

We can mention the RiskScore class, which centralize and provide all the calculation of risk points. Or the InsurancePlanAdvise class, which, based on the risk points already determined, suggests the best insurance plan. It's also worth commenting on the RiskProfileRules class, which centralizes and organizes all the execution of the user's risk profile assessment rules.

### Configuration
Configuration classes were implemented to make possible changes in rules values and request validations.

For example, to change the maximum age for eligibility for a life insurance, simply change the configuration file. No change to the source code is required.


