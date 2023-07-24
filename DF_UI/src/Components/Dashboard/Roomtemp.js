import react, { useState,useEffect } from 'react'
import axios from 'axios'
import { Stack, Typography } from '@mui/material'
import '../headermain.css'
import { Grid } from '@mui/material';
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import { styled } from '@mui/material/styles';
import CircularProgress from "@mui/material/CircularProgress";

function Temp() {
    const[current,setcurrent]=useState()
    const [isFetching, setIsFetching] = useState(true);
    const Item = styled(Paper)(({ theme }) => ({
        backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#1976d2 ',
        ...theme.typography.body2,
        padding: theme.spacing(1),
        textAlign: 'center',
        color: 'white',
    }));
    useEffect(() => {
        axios.get("https://datafactory001.azurewebsites.net/currentData")
            .then(res=>setcurrent(res.data))
            // .then(res => console.log("api", res))
            .catch(err => console.log(err))
    }, []);
    useEffect(() => {
        setTimeout(function () {
          console.log("Delayed for 5 second.");
          setIsFetching(false);
        //   window.location.reload(200000)
        }, 3000);
      }, []);
    
      if (isFetching) {
        return (
          <Box sx={{ display: "flex", justifyContent: "center" }}>
            <CircularProgress />
          </Box>
        );
      }
    return (
       

        <div className="roomtemp">
            {/* <Stack direction="column" spacing={3}>
           <Stack direction="row" spacing={20}>
               <Typography className="temp">Temperature</Typography>
               <Typography> 24.16c</Typography>
               </Stack>
               <Stack direction="row" spacing={20}>
               <Typography className="temp">Humidity</Typography>
               <Typography> 54.16RH</Typography>
               </Stack> 
               <Stack direction="row" spacing={20}>
               <Typography className="tempiaq">Indoor Air Quality(IAQ)</Typography>
               <Typography> 1.829 UAB</Typography>
               </Stack> 

               </Stack> */}
               
              
            <Box sx={{ flexGrow: 2 }}>
         { current &&
                current.map((item,i) => {
                    return(
                        
                <Grid container spacing={3} >
                    <Grid container spacing={5} item xs={12}>
                   
                        <Grid item xs={2}>
                            <Item> Current Temperature</Item>
                        </Grid>
                        
                        <Grid item xs={3}>
                           {item.temperature} C
                        </Grid>
                        <Grid>
                            </Grid>
                    </Grid>
                    <Grid  container spacing={5} item xs={12}>
                        <Grid item xs={2}>
                            <Item>Current Humidity </Item>
                        </Grid>
                        <Grid item xs={3}>
                       {item.humidity} RH
                        </Grid>
                    </Grid>
                    <Grid  container spacing={1} item xs={12}>
                        <Grid item xs={2.5}>
                            <Item>Current Indoor Air Quality(IAQ) </Item>
                        </Grid>
                        <Grid item xs={2}>
                        {item.iaq} UBA
                        </Grid>
                    </Grid>
                </Grid>
                
                    )
                 })}
                
            </Box>
               
        </div>
                
        
    )
                
}
export default Temp;