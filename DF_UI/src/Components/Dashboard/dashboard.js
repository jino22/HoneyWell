import Mainpage from './Home'
import '../headermain.css'
import Box from '@mui/material/Box';
import Sidebar from '../SideNavBar/Sidebar';
import Typography from '@mui/material/Typography';
function Dashboard(){
    return(
        <Box sx={{display:"flex" }}>
            <Sidebar/>
            <Mainpage/>                
        </Box>
    )
    
}
export default Dashboard