import React, { useEffect, useState } from 'react'
// import Data from './data.json';
import Button from '@mui/material/Button';
import { Stack, Typography } from '@mui/material'
import '../headermain.css'
import Table from './Tableinfo';
import axios from 'axios'
function Information() {
    const date = new Date()
    const [day, setDay] = useState("TODAY")
    const [tdate, settdate] = useState(new Date().toJSON().slice(0, 10))
    const [ldate, setldate] = useState(new Date().toJSON().slice(0, 10))
    const [tabledata, setTabledata] = useState([])
    const [flag, setFlag] = React.useState(false);
    const [flagyesterday, setFlagyesterday] = React.useState(true);
    const [flaglastweek, setFlaglastweek] = React.useState(true);
    const [wrapcss, setWrapcss] = React.useState("Buttonsalign")
    useEffect(() => {
        axios.get(`https://datafactory001.azurewebsites.net/Data?date=${day}`)
            .then(res=>setTabledata(res.data))
            // .then(res => console.log("api", res))
            .catch(err => console.log(err))
    }, [day]);


    console.log("tdate bufdy", tdate, ldate)


    console.log("api", tabledata)
    let dates = date.toJSON().slice(0, 10)
    console.log('Today date', dates)

    const ydate = new Date(date)
    ydate.setDate(ydate.getDate() - 1)
    let yesterdaydate = ydate.toJSON().slice(0, 10)
    console.log('Yesterday date', yesterdaydate)

    const wdate = new Date(date)
    wdate.setDate(wdate.getDate() - 7)
    let weekdate = wdate.toJSON().slice(0, 10)
    console.log('One week', weekdate)
    
    function handleClick() {
        settdate(dates)
        setldate(dates)
        setDay("TODAY")
        console.log("date", tdate)
        if (flagyesterday && flaglastweek) {

            setFlagyesterday(flagyesterday)
            setFlaglastweek(flaglastweek)
            setFlag(!flag)

        }
        else if(!flagyesterday && !flaglastweek)
        {
            setFlagyesterday(!flagyesterday)
            setFlaglastweek(!flaglastweek)
            setFlag(flag)
        }
        else if(!flagyesterday && flaglastweek)
        {
            setFlagyesterday(!flagyesterday)
            setFlaglastweek(flaglastweek)
            setFlag(!flag)
        }
        else if(flagyesterday && !flaglastweek)
        {
            setFlagyesterday(flagyesterday)
            setFlaglastweek(!flaglastweek)
            setFlag(!flag)
        }


    }
    function handleYesterdayClick() {
        settdate(yesterdaydate)
        setldate(yesterdaydate)
        setDay("YESTERDAY")
        console.log("date", tdate)
        if (flaglastweek && !flag) {
            // setFlagyesterday(flagyesterday)
            setFlag(!flag)
            setFlaglastweek(flaglastweek)
            setFlagyesterday(!flagyesterday)
        }
        else if(!flaglastweek&&flag){
            setFlag(flag)
            setFlaglastweek(!flaglastweek)
            setFlagyesterday(!flagyesterday)
        }


    }
    function handleLastweekClick() {
        settdate(weekdate)
        setDay("LASTWEEK")
        setldate(new Date().toJSON().slice(0, 10))
        console.log("date", tdate)
        if (flag && !flagyesterday) {
            setFlag(flag)
            setFlagyesterday(!flagyesterday)
            setFlaglastweek(!flaglastweek)
        }
        else if (!flag && flagyesterday) {
            setFlag(!flag)
            setFlagyesterday(flagyesterday)
            setFlaglastweek(!flaglastweek)
        }

    }

    function filterData(tabledata, tdate, ldate) {
        if (!tdate) return tabledata;
        console.log('Filtered data: ', tabledata.filter(data => data.timestamp.slice(0, 10) >= tdate && data.timestamp.slice(0, 10) <= ldate))
        return tabledata.filter(data => data.timestamp.slice(0, 10) >= tdate && data.timestamp.slice(0, 10) <= ldate).slice(0).sort((a, b) => a.timestamp.localeCompare(b.timestamp)).reverse();
    }
    console.log('Data:', tabledata)
   
    

  
    return (
        <div>
            <div className="Down">
                <Stack direction="row" style={{ width: "100%" }} spacing={25}>
                    {/* <Typography>
                        <label >Filter : </label>
                    </Typography>  */}
                    
                    <Typography className="Buttonsalign" component="div" sx={{ flexGrow: 1 }}>
                        <Button variant="contained" onClick={() => handleClick()} color={flag ? "primary" : "secondary"} style={{ marginLeft:"440px" }}>Today</Button>
                        {/* <Button variant="contained" onClick={() => handleYesterdayClick()} color={flagyesterday ? "primary" : "secondary"} style={{ marginLeft: '50px' }}>Yesterday</Button>
                        <Button variant="contained" onClick={() => handleLastweekClick()} color={flaglastweek ? "primary" : "secondary"} style={{ marginLeft: '50px' }}>Last One Week</Button> */}
                        {/* <button  className="filterbutton">Last One Week</button> */}
                    </Typography>
                    {/* {event.target.getAttribute('noWrap')?setWrapcss("Buttonsalign"):setWrapcss("Buttonswrapalign")} */}
                </Stack>
                <Table data={filterData(tabledata, tdate, ldate)} />


            </div>
        </div>
    )
}
export default Information;