import React, {useState} from 'react';
import axios from 'axios';
import moment from 'moment';
import {useHistory} from 'react-router-dom';
import './styles.css';

const CreateItem = ({ onItemCreated }) => {
  let history = useHistory();
  const [itemData, setItemData] = useState({
    title: "",
    body: ""
  });
  const { title, body } = itemData;
  const onChange = e => {
    const { name, value } = e.target;
    setItemData({
      ...itemData,
      [name]: value
    });
  };
  const create = async () => {
    if (!title) {
      console.log("Item name is required, description optional");
    } else {
      const newItem = {
        id: uuid.v4(),
        title: title,
        body: body,
        date: moment().toISOString()
      };
      try {
        const config = {
          headers: {
            "Content-Type": "application/json"
          }
        };

        const body = JSON.stringify(newItem);
        const res = await axios.item(
          "http://localhost:500/api/items",
          body,
          config
        );

        onItemCreated(res.data);
        history.push("/");
      } catch (error) {
        console.error(`Error adding item: ${error.response.data}`);
      }
    }
  };
  return (
    <div className="form-container">
      <h2>Add New Item</h2>
      <input
        name="title"
        type="text"
        placeholder="Item Name"
        value={title}
        onChange={e => onChange(e)}
      />
      <textarea
        name="body"
        cols="10"
        rows="5"
        value={body}
        onChange={e => onChange(e)}
      ></textarea>
      <button onClick={() => create()}> Submit </button>
    </div>
  );
};
export default CreateItem;