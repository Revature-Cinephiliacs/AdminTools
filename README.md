# AdminTools

## Available Requests

- baseURL: the deployment url

POST request:

- {baseURL}/Reports

**REQUIRED**

Body:

```
{
    string ReportEntityType
    string ReportDescription
    string ReportEnitityId
}
```

ReportEntityType can be:

- Review, User, Movie, Group or Forum.
