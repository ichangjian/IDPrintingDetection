#include "stdafx.h"
#include <opencv2/opencv.hpp>
#include "IDPrintingDetection.h"
#include "locMark.hpp"
using namespace cv;
using namespace IDPrintingDetection;
Mat image_st, image_sh;

void mark();
int IDPD::sum(int x, int y)
{
	mark();
	return x + y;
}

int IDPD::setShImage(IntPtr data, int width, int height)
{
	image_sh = Mat(height, width, CV_8UC3, (uchar*)data.ToPointer()).clone();
	imwrite("sh.png", image_sh);
	return 0;
}
int IDPD::setStImage(IntPtr data, int width, int height)
{
	image_st = Mat(height,width, CV_8UC3, (uchar*)data.ToPointer()).clone();
	imwrite("st.png", image_st);
	return 0;
}


void mark()
{
	Mat image1;// = imread("bei.jpg", 0);
	Mat image2;// = imread("bei-big.png", 0);
	Size imageSize = image1.size();
	cvtColor(image_st, image2, COLOR_BGR2GRAY);
	cvtColor(image_sh, image1, COLOR_BGR2GRAY);
	// Mat cameraMatrix=(Mat_<double>(3,3)<<3.2606318303148678e+03, 0., 1.9902589726153024e+03, 0.,3.2544394559854172e+03, 1.4792963284506968e+03, 0., 0., 1.);
	// Mat distCoeffs=(Mat_<double>(5,1)<<3.3748983542710012e-02, -8.1017183509675891e-02,-3.3142558829948004e-03, -1.5452809687960208e-03, 0.);
	Mat cameraMatrix = (Mat_<double>(3, 3) << 3.2439474859364700e+03, 0., 2.0088010945219005e+03, 0., 3.2379690414176052e+03, 1.4863769408813732e+03, 0., 0., 1.);
	Mat distCoeffs = (Mat_<double>(5, 1) << 1.3950461445044790e-01, -8.5094151077102653e-01, -2.6431370928322010e-03, 8.7808751132873724e-05, 1.5867377592585166e+00);

	Mat view, rview, map1, map2;
	initUndistortRectifyMap(cameraMatrix, distCoeffs, Mat(),
		getOptimalNewCameraMatrix(cameraMatrix, distCoeffs, imageSize, 1, imageSize, 0),
		imageSize, CV_16SC2, map1, map2);

	// remap(image1, image1, map1, map2, INTER_LINEAR);
	// imwrite("image1.jpg",image1);
	LocMark lm1(700, 10), lm2(500, 10);
	std::vector<Point2f> pts1, pts2;
	lm1.getMarkPosition(image1, pts1);
	lm2.getMarkPosition(image2, pts2);
	std::vector<Point2f> chess1, chess2, tp1, tp2;
	tp1.push_back(Point2f(0, 0));
	tp1.push_back(Point2f(image1.cols, 0));
	tp1.push_back(Point2f(image1.cols, image1.rows));
	tp1.push_back(Point2f(0, image1.rows));
	tp2.push_back(Point2f(0, 0));
	tp2.push_back(Point2f(image2.cols, 0));
	tp2.push_back(Point2f(image2.cols, image2.rows));
	tp2.push_back(Point2f(0, image2.rows));
	// undistortPoints(pts1,pts1,cameraMatrix,distCoeffs,cv::noArray(), cameraMatrix);

	for (size_t i = 0; i < 4; i++)
	{
		int mindist = 9999999;
		int minindex = 0;
		for (size_t j = 0; j < 4; j++)
		{
			double dist = abs(pts1[j].x - tp1[i].x) + abs(pts1[j].y - tp1[i].y);
			if (dist < mindist)
			{
				mindist = dist;
				minindex = j;
			}
		}
		chess1.push_back(pts1[minindex]);
	}

	for (size_t i = 0; i < 4; i++)
	{
		int mindist = 9999999;
		int minindex = 0;
		for (size_t j = 0; j < 4; j++)
		{
			double dist = abs(pts2[j].x - tp2[i].x) + abs(pts2[j].y - tp2[i].y);
			if (dist < mindist)
			{
				mindist = dist;
				minindex = j;
			}
		}
		chess2.push_back(pts2[minindex]);
	}
	for (size_t i = 0; i < 4; i++)
	{
		std::cout << tp1[i] << "\t" << tp2[i] << std::endl;
	}
	std::vector<uchar> status;
	Mat H = findHomography(chess1, chess2, RANSAC, 1, status, 1000, 0.999);
	// remap(image1, image1, map1, map2, INTER_LINEAR);
	// image1=imread("image1.jpg");
	Mat wp;
	warpPerspective(image1, wp, H, image2.size());
	imwrite("scen.png", wp);
}
