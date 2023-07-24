const express = require("express");
const { BlobServiceClient } = require("@azure/storage-blob");
const {Readable} = require("stream");
const app = express();
const router = express.Router();
// Middleware to parse JSON in request body
//app.use(express.json());
async function streamToString(readableStream) {
     const chunks = [];
     return new Promise((resolve, reject) => {
          readableStream.on("data", (data) => {
              chunks.push(data.toString()); });
               readableStream.on("end", () => {
                   resolve(chunks.join("")); });
                    readableStream.on("error", reject); });
                 }

    const connectionString = "DefaultEndpointsProtocol=https;AccountName=honeywellpocfileupload;AccountKey=D+XFBuC5xyVjvbePyiEWIOmNgVS1gXTbKtgFv7CzkEZwwXn2OlzkIlWWRiGa/gqlOPOxSOsGyTD/+AStYjSyxA==;EndpointSuffix=core.windows.net";
    const containerName = "autouploadpoc";
    const blobName = "Simulator_Config.json";
// Endpoint to handle JSON update request
router.put('/', async (req, res) => {
try {
// const connectionString = "DefaultEndpointsProtocol=https;AccountName=honeywellpocfileupload;AccountKey=D+XFBuC5xyVjvbePyiEWIOmNgVS1gXTbKtgFv7CzkEZwwXn2OlzkIlWWRiGa/gqlOPOxSOsGyTD/+AStYjSyxA==;EndpointSuffix=core.windows.net";
// const containerName = "autouploadpoc";
// const blobName = "Simulator_Config.json";
//const fieldToUpdate = req.body.fieldToUpdate;
const idToUpdate = req.body.sensor;
//const newValue = req.body.newValue;
const newJsonObject = req.body
// Create a BlobServiceClient
const blobServiceClient = BlobServiceClient.fromConnectionString(connectionString);

// Get a reference to the container
const containerClient = blobServiceClient.getContainerClient(containerName);

// Get a reference to the blob
const blobClient = containerClient.getBlobClient(blobName);
const blockBlobClient = blobClient.getBlockBlobClient();

// Upload the new JSON content to Azure Blob Storage
// Download the JSON file
const downloadResponse = await blockBlobClient.download(0);
const existingJsonContent = await streamToString(downloadResponse.readableStreamBody);
const jsonContent = JSON.parse(existingJsonContent);

// Find the JSON object with the matching ID
const indexToUpdate = jsonContent.findIndex((obj) => obj.sensor === idToUpdate);

if (indexToUpdate !== -1) {
jsonContent[indexToUpdate] = newJsonObject;

// Upload the updated JSON content to Azure Blob Storage
const updatedJsonContent = JSON.stringify(jsonContent);
const uploadResponse = await blockBlobClient.upload(updatedJsonContent, updatedJsonContent.length, {
blobHTTPHeaders: { blobContentType: "application/json" },
overwrite: true,
});


res.status(200).json({ message: "JSON file updated successfully!" });
}}
catch (error) {
console.error("Error updating JSON field in Blob Storage:", error);
res.status(500).json({ error: "An error occurred while updating JSON field." });
}

});

router.get('/', async (req, res) => {
    try {
    // const connectionString = "DefaultEndpointsProtocol=https;AccountName=honeywellpocfileupload;AccountKey=D+XFBuC5xyVjvbePyiEWIOmNgVS1gXTbKtgFv7CzkEZwwXn2OlzkIlWWRiGa/gqlOPOxSOsGyTD/+AStYjSyxA==;EndpointSuffix=core.windows.net";
    // const containerName = "autouploadpoc";
    // const blobName = "Simulator_Config.json";
    // Create a BlobServiceClient
    const blobServiceClient = BlobServiceClient.fromConnectionString(connectionString);
   
    // Get a reference to the container
    const containerClient = blobServiceClient.getContainerClient(containerName);
   
    // Get a reference to the blob
    const blobClient = containerClient.getBlobClient(blobName);
    const blockBlobClient = blobClient.getBlockBlobClient();
   
    // Upload the new JSON content to Azure Blob Storage
    // Download the JSON file
    const downloadResponse = await blockBlobClient.download(0);
    const existingJsonContent = await streamToString(downloadResponse.readableStreamBody);
    const jsonContent = JSON.parse(existingJsonContent);
    //res.json(jsonContent);
   
    // res.status(200).json({ message: "JSON file retreived successfully!" });
    sendResponse(res, 200, jsonContent);
    }
    catch (error) {
    console.error("Error while retreving the data:", error);
    res.status(500).json({ error: "An error occurred while receving Data." });
    }
   
   
    });
    // Helper function to send the response
function sendResponse(res, status, data) {
    if (!res.headersSent) {
      res.status(status).json(data);
    }
   }

module.exports = router;

