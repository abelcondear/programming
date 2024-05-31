#include <map>

// selected to be exported
template<typename K, typename V>

class interval_map {
	friend void IntervalMapTest();

	V m_valBegin;

	std::map<K,V> m_map;

public:

	interval_map(V const& val)
	: m_valBegin(val)
	{}


	void assign( K const& keyBegin, K const& keyEnd, V const& val ) {
        int static n = 0;
        int b = (int)keyBegin;
        int e = (int)keyEnd;

        if (!( b < e )) {
            m_map.insert({NULL,NULL});
            return;
        } 
        
        bool found = false;

        for (auto& it : m_map) {
            if (it.second == val) {
                found = true;
                break;
            }
        }
        
        if (found) {
            return; //exit function --should not insert repeated value
        }

        for ( int key = keyBegin; key <= keyEnd; key ++ )
        {
            // cannot insert first value equals to m_valBegin
            if (!(n == 0 && val == m_valBegin)) 
            {
                m_map.insert({key,val});
                n ++;
            }
        }



	}

	// look-up of the value associated with key
	V const& operator[]( K const& key ) const { 
        //returns the value "V" corresponding to the K value

        //search Key trying to read Key parameter calling map method upper_bound
		auto it=m_map.upper_bound(key); 
        

		if(it==m_map.begin()) {
			return m_valBegin;
		} else {
			return (--it)->second;
		}

	}
};

void IntervalMapTest() {
    // TODO
}