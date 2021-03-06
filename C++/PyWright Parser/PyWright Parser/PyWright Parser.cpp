// PyWright Parser.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <sstream>
#include <string>
#include <vector>


using namespace std;

// assumed structure is:

// name | emote <-- header

// line 1
// line 2 <-- can be a new line or an actual line
// line 3 <-- can be a new line or an actual line
// whitespace

string parse_header(const string* header)
{
	string d_header = *header; // dereferenced header
	string line = "";

	if (!d_header.empty())
	{
		string delim = " | ";

		// is the string a header?
		if (d_header.find(delim) != string::npos)
		{
			// name [0] | emote [1]
			string header[2];
			int index = 0;
			size_t pos = 0;
			while ((pos = d_header.find(delim)) != string::npos || index < 2)
			{
				header[index] = d_header.substr(0, pos);
				d_header.erase(0, pos + delim.length()); // erase what was just added to the header

				++index;
			}

			line.append("char ");
			line.append(header[0]);
			line.append(" e=");
			line.append(header[1]);
			line.append("\n");
		}
	}

	return line;

}

int main()
{
	string path; // input path
	string o_path; // output path
	cout << "Enter a file path: ";
	cin >> path; // sets user input to path
	cout << "Enter output path: ";
	cin >> o_path;

	ifstream file; // input file
	ofstream o_file; // output file

	file.open(path);
	o_file.open(o_path);

	int l = 0;	// marks line number

	string line; // unparsed line
	string p_line; // parsed line

	// read from file
	while (getline(file, line))
	{
		if (!line.empty())
		{
			switch (l)
			{
			case 0:
				p_line = parse_header(&line);
				break;
			case 1:
				// add beginning quote
				p_line += "\"";
			case 2:
				p_line += line;
				p_line += "{n}";
				break;
			case 3:
				p_line += line;
				p_line += "\"";
				p_line += "\n";

				// write to file
				o_file << p_line << endl;

				p_line = "";
				l = -1;
			}
			++l;
		}

	}

	file.close();
	o_file.close();

	cin >> path;
	return 0;
}

