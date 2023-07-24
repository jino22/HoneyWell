import Simulator from './Simulatorcall'
import '../headermain.css'
import Box from '@mui/material/Box';
import Sidebar from '../SideNavBar/Sidebar';
function Dashboard(){
    return(
        <Box sx={{ display: 'flex' }}>
            <Sidebar/>
<div>
            <Simulator />
            </div>           
        </Box>
    )
    
}
export default Dashboard