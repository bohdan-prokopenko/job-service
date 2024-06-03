## Build and Run Locally
1. Open the project in Visual Studio.
2. Build the solution.
3. Run the application.
4. Send a POST request:
5. Use a tool like Postman.
6. URL: http://localhost:5000/api/job
7. Body: Provide job details in JSON format.
------------
## Build Docker Image
1. Navigate to the solution directory.
2. Build the Docker image:
```bash
docker build -t jobservice-api .
```
3. Run the Docker container:
```bash
docker run -d -p 8081:8080 jobservice-api
```
------------
## Deploy to Kubernetes with Helm
1. Package the Helm chart:
```bash
helm package ./deployment-configuration
```
2. Deploy the chart:
```bash
helm install job-service ./job-service-0.1.0.tgz
```
------------
### [Requests](http://https://raw.githubusercontent.com/bohdan-prokopenko/job-service/main/api/JobService.Api.http "Requests")
