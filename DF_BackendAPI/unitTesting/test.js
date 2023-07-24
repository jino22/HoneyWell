// const request = require('supertest');
// //jest.setTimeout(50000)
// const app = require('../app');
// describe('POST /api/data', () => {
//  afterEach(() => {
//    jest.clearAllMocks();
//  });

//  test('should save data in MongoDB', async () => {
//    const mockPostData = {
//     "id": 997809,
//     "floor_ref_id": "11",
//     "room_ref_id": "IGK61A03",     
//     "timestamp": "2023-06-29T15:43:25Z",
//     "motion_detected": false,   
//     "humidity": 39.17    ,
//     "temperature":  34.64,
//     "iaq":  1.929,
//     "sensor": "55B-HRH",
//     "device_Type":"Printer-HRHWTG2023"    
// };
//    const mockSavedPost ={
//     "message": "Data saved successfully"
// };
//    await request(app)
//      .post('/api/data')
//      .send(mockPostData)
//      .expect(201)
//      .then((response) => {
//        expect(response.body).toEqual(mockSavedPost);
//      });
//  });
// });

const {send}  = require('../version1/postCall');
const { createRequest, createResponse } = require('node-mocks-http');
const { dataSchema } = require('../shared/model');
//jest.mock('../shared/model');

// jest.mock('../shared/model', () => {
//   const saveMock = jest.fn().mockResolvedValue({ _id: '12345' });
 
//   class MockPost {
//     constructor(data) {
//       Object.assign(this, data);
//     }
 
//     save() {
//       return saveMock();
//     }
//   }
 
//   return { dataSchema: MockPost };
//  });

//  jest.setTimeout(500000);
 
 
// describe('POST /api/posts', () => {
//  test('should store the post in the MongoDB database', async () => {
//    const req = createRequest({
//     method:'POST',
//     url: '/api/posts',
//      body: {
//       "id": '123123',
//       "floor_ref_id": "11",
//       "room_ref_id": "IGK61A10",     
//       "timestamp": "2023-07-03T16:43:25Z",
//       "motion_detected": false,   
//       "humidity": 39.17    ,
//       "temperature":  34.64,
//       "iaq":  1.929,
//       "sensor": "55B-HRH",
//       "device_Type":"Printer-HRHWTG2023"    
//   },
//    });
//    const res = createResponse();

//    await router(req, res);
//    //console.log(res);

//    expect(res.statusCode).toBe(201);
//    expect(res._getData()).toEqual(JSON.stringify({ postId: '12345' }));
//   //  expect(res.finished).toBe(true);
//   //  expect(res._isJSON()).toBe(true);
//  });
// });

jest.mock('../shared/model', () => {
  const saveMock = jest.fn().mockResolvedValue({ _id: '12345' });
 
  class MockPost {
    constructor(data) {
      Object.assign(this, data);
    }
 
    save() {
      return saveMock();
    }
  }
 
  return { dataSchema: MockPost };
 });
//console.log(test);

describe('POST /api/posts', () => {
 test('should store the post in the MongoDB database', async () => {
  //  const saveMock = jest.fn().mockResolvedValue({ _id: '12345' });
  //  dataSchema.prototype.save = saveMock;

   const req = createRequest({
     method: 'POST',
     url: '/api/posts',
     body: {
      "id": 524869,
      "floor_ref_id": "11",
      "room_ref_id": "IGK61A03",     
      "timestamp": "2023-06-29T15:43:25Z",
      "motion_detected": false,   
      "humidity": 39.17    ,
      "temperature":  34.64,
      "iaq":  1.929,
      "sensor": "55B-HRH",
      "device_Type":"Printer-HRHWTG2023"    
  },
   });
   const res = createResponse();
   //console.log(res);
   await send(req, res);
   expect(res.statusCode).toBe(201);
   expect(res._getData()).toEqual(JSON.stringify({ postId: '12345' }));
   expect(saveMock).toHaveBeenCalledTimes(1);
 });
});