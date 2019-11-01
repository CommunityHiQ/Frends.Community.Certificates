# Frends.Community.Certificates
FRENDS task for certificate operations.

- [Installing](#installing)
- [Tasks](#tasks)
  - [Get User Info](#getuserinfo)
- [License](#license)
- [Building](#building)
- [Contributing](#contributing)
- [Change Log](#change-log)

# Installing
You can install the task via FRENDS UI Task View or you can find the nuget package from the following nuget feed
'Nuget feed coming at later date'

Tasks
=====

## FindExpiring

Finds certificates that are expiring within the given amount of days.

### Task Parameters


| Property             | Type                 | Description                          | Example |
| ---------------------| ---------------------| ------------------------------------ | ----- |
| ExpiresIn | int | The amount of days within which the certificate expires |
| IssuedBy | string | The issuer of the certificate that should be searched for  |  |


### Result
| Property             | Type                 | Description                          | Example |
| ---------------------| ---------------------| ------------------------------------ | ----- |
|  | JToken | A JObject with the properties "Found expiring" (true/false) and "Expiring" (a JToken array of certificates) |  |

# License

This project is licensed under the MIT License - see the LICENSE file for details

# Building

Clone a copy of the repo

`git clone `

Restore dependencies

`nuget restore `

Rebuild the project

Run Tests with nunit3. Tests can be found under

``

Create a nuget package

`nuget pack nuspec/`

# Contributing
When contributing to this repository, please first discuss the change you wish to make via issue, email, or any other method with the owners of this repository before making a change.

1. Fork the repo on GitHub
2. Clone the project to your own machine
3. Commit changes to your own branch
4. Push your work back up to your fork
5. Submit a Pull request so that we can review your changes

NOTE: Be sure to merge the latest from "upstream" before making a pull request!

# Change Log

| Version             | Changes                 |
| ---------------------| ---------------------|
| 1.0.0 | Initial version of task |
