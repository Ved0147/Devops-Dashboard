import axios from "axios";

import { DashboardOverview } from "../types/dashboard";

const API_URL = "http://localhost:5214/api";

export const getDashboardOverview = async (): Promise<DashboardOverview> => {
  const response = await axios.get<DashboardOverview>(
    `${API_URL}/dashboard/overview`
  );

  return response.data;
};