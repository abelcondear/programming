// 11:44 Start
// 15:44 End

// Task Description
// interval_map<K,V> is a data structure that associates 
// keys of type K with values of type V. It is designed to be 
// used efficiently in situations where intervals of consecutive 
// keys are associated with the same value. Your task is to implement 
// the assign member function of this data structure, which is 
// outlined below.

// interval_map<K, V> is implemented on top of std::map. 
// For more information on std::map, you may refer to 
// cppreference.com.

// Each key-value-pair (k,v) in interval_map<K,V>::m_map means 
// that the value v is associated with all keys from k (including) 
// to the next key (excluding) in m_map. The member 
// interval_map<K,V>::m_valBegin holds the value that is associated 
// with all keys less than the first key in m_map.
