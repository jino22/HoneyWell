const express = require('express');
const dbManager = require("./shared/db.connect.js");
const app = express();
app.use(express.json());
dbManager.mongoConnect();

// Import your separate script files
const GetSimulatorData = require('./version1/GetSimulatorData');
const SendCommand = require('./version1/SendCommand');
const CurrentData = require('./version1/currentData');
const SendUiCommand = require('./version1/SendUiCommand');
const SendMultipleCommand = require('./version1/sendMultipleCommands')
const LoginAPI = require('./version1/loginAPI');
const UiCommand = require('./version1/uiCommand.js')
const testApi = require('./version1/postCall.js')

//const script3 = require('./script3');

//// Import your separate script files(with JWT token)
const GetSimulatorData2 = require('./version2/GetSimulatorData');
const SendCommand2 = require('./version2/SendCommand');
const CurrentData2 = require('./version2/currentData');
const LoginAPI2 = require('./version2/loginAPI');
const SendUiCommand2 = require('./version2/SendUiCommand');

// Define routes for each script
app.use('/Data', GetSimulatorData);
app.use('/api/data', SendCommand);
app.use('/currentData', CurrentData)
app.use('/Ui',SendUiCommand )
app.use('/api/listOfCommands',SendMultipleCommand);
app.use('/login',LoginAPI);
app.use('/api/json', UiCommand)

app.use('/v2/Data', GetSimulatorData2);
app.use('/v2/api/data', SendCommand2);
app.use('/v2/currentData', CurrentData2)
app.use('/v2/login/', LoginAPI2)
app.use('/v2/Ui', SendUiCommand2)

app.use((req,res) =>{
    res.status(404).json({
        error : 'Endpoint not found'
    })
})

//server details
const server = app.listen(8080, () => {
 console.log('Server is running on port 8080');
});

module.exports = server