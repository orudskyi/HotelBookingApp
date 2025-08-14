import { useState, useEffect } from 'react';
import hotelService, { type Hotel } from '../services/hotelService';

const HotelsPage = () => {
  const [hotels, setHotels] = useState<Hotel[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchHotels = async () => {
      try {
        const response = await hotelService.getAllHotels();
        setHotels(response.data);
      } catch (err) {
        setError('Failed to fetch hotels.');
        console.error(err);
      } finally {
        setLoading(false);
      }
    };

    fetchHotels();
  }, []); // Empty dependency array means this effect runs once after the initial render

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div style={{ color: 'red' }}>{error}</div>;
  }

  return (
    <div>
      <h1>Available Hotels</h1>
      <ul>
        {hotels.map((hotel) => (
          <li key={hotel.id}>
            {hotel.name} - {hotel.city}, {hotel.country} (Rating: {hotel.rating})
          </li>
        ))}
      </ul>
    </div>
  );
};

export default HotelsPage;