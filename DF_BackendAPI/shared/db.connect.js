const mongooseInstance = require("mongoose");

//get server connection string
//let connectionString = process.env.MONGODB_CONNECTION_STRING || 'mongodb://edgyneer-api-cosmosdb:EuX6xwwhdIb4hn48ZdWF3pRO2b7G4URw7ryYMuQnKqoKUcl0YhjIH8NRkMbKoHdffr9SrqZstkPqACDbz2kUww==@edgyneer-api-cosmosdb.mongo.cosmos.azure.com:10255/test?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@edgyneer-api-cosmosdb@';
let connectionString = 'mongodb+srv://mongo:nF4TIG8ylmkCuwE2@digitalfactory.wh2fkoh.mongodb.net/IotSimulatorDb?retryWrites=true&w=majority'
async function mongoConnect() {
    //mongoose instance connection
    mongooseInstance.Promise = global.Promise;
    return new Promise((resolve, reject) => {
        if (mongooseInstance.connection.readyState == 0 || mongooseInstance.connection.readyState == 3) {
            // Connecting to the database
            mongooseInstance.connect(connectionString, {
                useNewUrlParser: true
            }).then((res) => {
                connection = res;
                console.log("Successfully connected to the database");
                resolve(connection)
            }).catch(err => {
                console.log('Could not connect to the database. Exiting now...', err);
                reject(new customError('DB_CONNECTION_ERROR', 'Could not connect to the database.'));
            });
        } else {
            console.log("Already connected to the database");
            resolve(mongooseInstance.connection)
        }
    });
    // mongooseInstance.connect(connectionString);
    // console.log("Successfully connected to the database");
    // mongoose.Promise = global.Promise
}

// var db = mongooseInstance.connection;
// db.on('connecting', function () {
//     console.log('connecting');
// });
// db.on('error', function (error) {
//     console.error('Error in MongoDb connection: ' + error);
//     mongooseInstance.disconnect();
// });
// db.on('connected', function () {
//     console.log('connected!');
// });
// db.once('open', function () {
//     console.log('connection open');
// });
// db.on('reconnected', function () {
//     console.log('reconnected');
// });
// db.on('disconnected', function () {
//     console.log('disconnected');
//     console.log('dbURI is: ' + dbURI);
//     mongooseInstance.connect(connectionString,
//         {
//             server: {
//                 auto_reconnect: true,
//                 socketOptions: { keepAlive: 1, connectTimeoutMS: 30000 }
//             },
//             replset: { socketOptions: { keepAlive: 1, connectTimeoutMS: 30000 } }
//         });
// });

module.exports = {
    mongoConnect
};

