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
