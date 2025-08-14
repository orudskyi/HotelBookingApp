import apiInstance from '../api/axiosConfig';

export interface Hotel {
  id: number;
  name: string;
  rating: number;
  city: string;
  country: string;
}

const getAllHotels = () => {
  return apiInstance.get<Hotel[]>('/hotels');
};

const hotelService = {
  getAllHotels,
};

export default hotelService;