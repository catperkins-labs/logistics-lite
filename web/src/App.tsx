import { BrowserRouter, Routes, Route, NavLink } from "react-router-dom";
import LoginPage from "./pages/LoginPage";
import ItemsPage from "./pages/ItemsPage";
import InventoryPage from "./pages/InventoryPage";
import ScannerModePage from "./pages/ScannerModePage";
import "./App.css";

function App() {
  return (
    <BrowserRouter>
      <nav>
        <NavLink to="/login">Login</NavLink>
        <NavLink to="/items">Items</NavLink>
        <NavLink to="/inventory">Inventory</NavLink>
        <NavLink to="/scanner">Scanner Mode</NavLink>
      </nav>
      <main>
        <Routes>
          <Route path="/" element={<LoginPage />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/items" element={<ItemsPage />} />
          <Route path="/inventory" element={<InventoryPage />} />
          <Route path="/scanner" element={<ScannerModePage />} />
        </Routes>
      </main>
    </BrowserRouter>
  );
}

export default App;
