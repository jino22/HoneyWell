import logo from './logo.svg';
import './App.css';
import Headers from './Components/Header'
import Roomtemperature from './Components/Dashboard/Roomtemp'
import Tablesdata from './Components/Dashboard/Table'
import Dashboard from './Components/Dashboard/dashboard';
import Simulator from './Components/SimulatorDetails/Simulator'
import {BrowserRouter as Router,Routes,Route} from 'react-router-dom'
import Reports from './Components/Reports/Report'
import Sidebar from './Components/SideNavBar/Sidebar';
import FormValidation from './Components/loginpage';
function App() {
  return (
    <div className="App">
      {/* <Headers/> */}
      <Routes>
      <Route path="/" element={<FormValidation/>}></Route>
        <Route path="/dashboard" element={<Dashboard/>}></Route>
        <Route path="/simulator" element={<Simulator/>}></Route>
        <Route path="/reports" element={<Reports/>}></Route>
      </Routes>

    </div>
  );
}

export default App;
