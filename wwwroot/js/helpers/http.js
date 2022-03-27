const httpGet = async (url) => {
  try {
    const res = await axios.get(url);
    if (res.status == 200) {
      return {
        isSuccess: true,
        data: res.data,
      };
    }
  } catch (err) {
    return {
      isSuccess: false,
      message: err.message,
      status: err.response.status,
    };
  }
};

const httpPost = async (url, data) => {
  try {
    const res = await axios.post(url, data);
    if (res.status == 200 || res.status == 201) {
      return {
        isSuccess: true,
        data: res.data,
      };
    }
  } catch (err) {
    return {
      isSuccess: false,
      message: err.message,
      status: err.response.status,
    };
  }
};

const httpDelete = async (url) => {
  try {
    const res = await axios.delete(url);
    if (res.status == 200) {
      return {
        isSuccess: true,
        data: res.data,
      };
    }
  } catch (err) {
    return {
      isSuccess: false,
      message: err.message,
      status: err.response.status,
    };
  }
};
