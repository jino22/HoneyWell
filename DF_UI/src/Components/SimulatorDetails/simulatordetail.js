// function Simulator(){
// return(
//     <div>
//         <h1 href={`/simulatordetails`} >Simulator Details</h1>
//     </div>
// )
// }
// export default Simulator
// import * as React from 'react';
// import { styled } from '@mui/material/styles';
// import Grid from '@mui/material/Grid';
// import Paper from '@mui/material/Paper';
// import Box from '@mui/material/Box';
// import { Stack } from '@mui/system';
// import Card from '@mui/material/Card';
// import CardActions from '@mui/material/CardActions';
// import CardContent from '@mui/material/CardContent';
// import CardMedia from '@mui/material/CardMedia';
// import Button from '@mui/material/Button';
// import Typography from '@mui/material/Typography';

// const Item = styled(Paper)(({ theme }) => ({
//   backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
//   ...theme.typography.body2,
//   padding: theme.spacing(1),
//   textAlign: 'center',
//   color: theme.palette.text.secondary,
// }));

// export default function RowAndColumnSpacing() {
//   return (
//     <Card sx={{ maxWidth: 345 }}>
//         <table>
//             <thead>
         
//             </thead>
//         </table>
//         </Card>
   
//   );
// }
import * as React from 'react';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Dialog from '@mui/material/Dialog';
import react, { useState,useEffect } from 'react'
import axios from 'axios'
import {
  Grid
} from '@material-ui/core/'

import '../headermain.css'
export default function ImgMediaCard() {
      

    // {carddata?.map((item)=>{
    //   return(
        // }
    //   )
    // })}

    
    // function changeText(reed) {
    //   reed.innerHTML = "COPIED!";
    //   var reedText = reed.previousSibling;
    //   navigator.clipboard.writeText(reedText.textContent);
      
    // }
//     const buttons = document.querySelectorAll('button');
// buttons.forEach((button) => {
//   button.addEventListener('click', () => {
//     alert(`You pressed ${button.innerHTML}!`)
//     { carddata?.map((item) => {
//       return(

//       )
//     })}
//     // Do something
//   })
// });
    
    
      // {carddata?.map((item)=>{
      //   function handlebutton(){
      //   return(
          
      //       {item.Command=="Stop"?
           
      //   )
      //   }
      // })}
    //   {carddata?.map((item)=>{
    //   function handlebutton  () {
        
    //     // console.log(item?.Command, "statusvgv")
    //     //  Case 1 item.Command  === "STOP"
    //     if(item?.currentjobstatus == "Running"){
    //       setRunningStatus("Stop")
    //     }
    //     else{
    //       setRunningStatus("Start")
    //     }

    //     console.log("runnign Status", runningStatus);
    //   }
    // })}
    const [carddata, setCarddata] = useState([])
   
   
    const[status,setStatus]=useState("Start")
    useEffect(() => {
        axios.get("https://datafactory001.azurewebsites.net/Ui")
            .then(res=>setCarddata(res.data))
            // .then(res => console.log("api", res))
            .catch(err => console.log(err))
    }, []);
    
    function Dialog(){
      return(
        <h3></h3>
      )
    }
    
    const [runningstatus, setRunningStatus] = useState("")
    function handleChange(id,status){
    
      return(
        <>
        {id&&status=="Running"?setRunningStatus("Stoped"):setRunningStatus("Running")}
        </>
      )
    }
  return (
    <div style={{marginTop:"100px"}}>
      <Grid
                container
                spacing={5}
                direction="row"
                justify="flex-start"
                alignItems="flex-start"
            >
      { carddata?.map((item) => {
        return(
          <Grid item xs={12} sm={6} md={3}>

        <Card  style={{width:"100%", marginRight:'100px', marginBottom:'5px',float:'left'}}sx={{ maxWidth: 345 }}>
        
      <CardContent style={{width:"105%", paddingLeft:"-16px"}}>
         {/* {item._id==} */}
      
       <table >
           <thead>
               <tr>
             <th colspan="2" style={{backgroundColor:"#87CEEB"}}> {item.simulatorname}</th> 
             </tr> 
             </thead>
             <tr >  
             <th>Sensor</th>
             <th> Time Interval</th>
            </tr>
            <tr style={{backgroundColor:"#FFFFE0"}}>  
             <th>{item.sensor}</th>
             <th>{item.timer} {item.timertype}</th>
            </tr>
            <tr style={{backgroundColor:"white"}}>  
             <th>Running Status</th>
            <th style={{color:item.currentjobstatus=="Running"?"green":"red"}}> {item.currentjobstatus}</th>
            </tr>
            <tr>  
             <th></th>
             <th><Button variant="outlined" id={item._id} onClick={()=>handleChange(item._id,item.currentjobstatus)}>{item.currentjobstatus=="Stoped"?"Start":"Stop"}</Button></th>
             {/* <th id={item._id}><input id="button1" type="button" onClick={changeValue(e)} value={item.currentjobstatus=="Stoped"?"Start":"Stop"}/></th> */}
            </tr>

           
        
       </table>
       
      </CardContent>
     
    </Card>
    </Grid>
        )
     })}
     </Grid>
    </div>
  );
}